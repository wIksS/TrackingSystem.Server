using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackingSystem.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using TrackingSystem.ViewModels;

namespace TrackingSystem.Controllers
{
    public class TeacherController : BaseController
    {
        public TeacherController()
            : base()
        {
        }

        public int AppliCationUserViewModel { get; private set; }

        [HttpGet]
        public ICollection<TeacherViewModel> GetAllTeachers()
        {
            var teachers = this.Data.Teachers.All().Project().To<TeacherViewModel>().ToList();

            return teachers;
        }
    }
}