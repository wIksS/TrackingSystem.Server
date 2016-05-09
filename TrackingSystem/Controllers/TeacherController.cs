namespace TrackingSystem.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.ViewModels;

    public class TeacherController : BaseController
    {
        private readonly ITeachersService teachers;

        public TeacherController(ITeachersService teachersService)
        {
            this.teachers = teachersService;
        }

        /// <summary>
        /// Returns all teachers
        /// </summary>
        /// <returns>ICollection<TeacherViewModel></returns>
        [HttpGet]
        public ICollection<TeacherViewModel> GetAllTeachers()
        {
            var teachers = this.teachers.GetAll().AsQueryable().Project().To<TeacherViewModel>().ToList();

            return teachers;
        }
    }
}