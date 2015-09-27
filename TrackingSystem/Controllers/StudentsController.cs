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

namespace TrackingSystem.Controllers
{
    [Authorize]    
    public class StudentsController : BaseController
    {
        [HttpGet]
        public ICollection<ApplicationUserViewModel> GetGroupAvaiableStudents()
        {
            var teacherId = User.Identity.GetUserId();
            if (!Data.Teachers.All().Any(t => t.Id == teacherId))
            {
                return null;
            }

            var teacher = Data.Teachers.Find(teacherId);

            var students = Data.Students.All().Where(s => s.Group != teacher.Group).Cast<ApplicationUser>().ToList();
            var studentsViewModel = Mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(students);

            return studentsViewModel;
        }

        [HttpPost]
        public IHttpActionResult AddStudentToGroup(string id)
        {
            var teacherId = User.Identity.GetUserId();
            var teacher = Data.Teachers.Find(teacherId);
            var student = Data.Students.All().FirstOrDefault(s => s.UserName == id);

            if (teacher == null || student == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            if (teacher.Group == null)
            {
                var group = new Group();
                group.Teacher = teacher;
                Data.Groups.Add(group);
                Data.Groups.SaveChanges();
                teacher.Group = group;
            }

            teacher.Group.Students.Add(student);
            student.Group = teacher.Group;
            Data.Groups.SaveChanges();

            return Ok();
        }

        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}