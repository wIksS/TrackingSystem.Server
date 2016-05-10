namespace TrackingSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.Services.Web;
    using TrackingSystem.ViewModels;
    using TrackingSystem.Common.Mapping;

    public class TeacherController : BaseController
    {
        private readonly ITeachersService teachers;
        private readonly ICacheService cache;
        public TeacherController(ITeachersService teachersService, ICacheService cacheService)
        {
            this.teachers = teachersService;
            this.cache = cacheService;
        }

        /// <summary>
        /// Returns all teachers
        /// </summary>
        /// <returns>ICollection<TeacherViewModel></returns>
        [HttpGet]
        public ICollection<TeacherViewModel> GetAllTeachers()
        {
            var teachers =this.cache.Get("teachers", () => this.teachers.GetAll().AsQueryable().To<TeacherViewModel>().ToList(), 30 * 60);

            return teachers;
        }
    }
}