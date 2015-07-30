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
    public class UsersController : BaseController
    {
        // GET: Users
        [HttpGet]
        [Authorize]
        public ICollection<ApplicationUserViewModel> GetGroupAvaiableStudents()
        {
            var teacherId = User.Identity.GetUserId();
            var teacher = Data.Teachers.Find(teacherId);

            if (teacher == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));                
            }

            var students = Data.Students.All().Cast<ApplicationUser>().ToList();
            var studentsViewModel = Mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(students);

            return studentsViewModel;
        }
    }
}