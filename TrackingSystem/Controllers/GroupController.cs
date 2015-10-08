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
    public class GroupController : BaseController
    {
        public GroupController()
            : base()
        {
        }

        [HttpPost]
        public GroupViewModel ChangeGroupDistance([FromUri]int newDistance)
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser user = Data.Teachers.Find(userId);

            var group = user.Group;

            if (group == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            group.MaxDistance = newDistance;
            this.Data.Groups.SaveChanges();

            var groupViewModel = Mapper.Map<GroupViewModel>(group);

            return groupViewModel;
        }

        [HttpGet]
        public GroupViewModel GetGroup()
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser user;

            if (Data.Students.All().Any(s => s.Id == userId))
            {
                user = Data.Students.Find(userId);
            }
            else
            {
                user = Data.Teachers.Find(userId);
            }

            var group = user.Group;

            if (group == null)
            {
                group = new Group()
                {
                    MaxDistance = AppConstants.MaxDistance,                    
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
