using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackingSystem.Data;
using TrackingSystem.ViewModels;
using Microsoft.AspNet.Identity;
using TrackingSystem.Models;
using AutoMapper;
using TrackingSystem.Helpers;
using TrackingSystem.Infrastructure;


namespace TrackingSystem.Controllers
{
    [Authorize]
    [RoutePrefix("api/Group")]
    public class GroupController : BaseController
    {
        public GroupController()
            : base()
        {
        }

        [HttpPost]
        public IHttpActionResult ChangeGroupDistance([FromUri]int newDistance, [FromUri]string id)
        {
            var userId = id;
            if (userId == null)
            {
                userId = User.Identity.GetUserId();
            }
            if (Data.Teachers.All().FirstOrDefault(t => t.Id == userId) == null)
            {
                return BadRequest("You can set the tracking distance only for a teacher");
            }
            ApplicationUser user = Data.Teachers.Find(userId);
            var group = user.Group;

            if (group == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            group.MaxDistance = newDistance;
            this.Data.Groups.SaveChanges();

            var groupViewModel = Mapper.Map<GroupViewModel>(group);

            return Ok(groupViewModel);
        }

        [Route("GetStudentsInGroup")]
        public ICollection<ApplicationUserViewModel> GetStudentsInGroup(string id = null)
        {
            var userId = id;
            if (userId == null)
            {
                userId = User.Identity.GetUserId();
            }

            ApplicationUser user = Data.Users.Find(userId);

            if (user == null || user.Group == null)
            {
                return null;
            }

            var students = user.Group.Students.Cast<ApplicationUser>().ToList();

            var studentsViewModel = Mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(students);

            return studentsViewModel;
        }

        [Route("RemoveFromGroup")]
        public IHttpActionResult RemoveFromGroup([FromUri]string id)
        {
            string userName = id;
            Student user = Data.Students.All().First(s => s.UserName == userName); ;

            if (user == null)
            {
                return null;
            }

            if (user.Group != null)
            {
                var group = user.Group;

                user.Group = null;
                user.GroupId = null;

                group.Students.Remove(user);
                Data.Students.SaveChanges();
            }

            return Ok();
        }

        [Route("GetGroup")]
        public GroupViewModel GetGroup()
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser user;
            bool isTeacher = false;

            if (Data.Students.All().Any(s => s.Id == userId))
            {
                user = Data.Students.Find(userId);
            }
            else
            {
                user = Data.Teachers.Find(userId);
                isTeacher = true;
            }

            var group = user.Group;

            if (group == null && isTeacher)
            {
                group = new Group()
                {
                    MaxDistance = AppConstants.MaxDistance,
                    Teacher = user as Teacher,
                    TeacherId = user.Id
                };

                this.Data.Groups.Add(group);
                user.Group = group;
                this.Data.Groups.SaveChanges();
            }

            var groupViewModel = Mapper.Map<GroupViewModel>(group);

            return groupViewModel;
        }
    }
}
