namespace TrackingSystem.Controllers
{
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.ViewModels;

    [Authorize]
    public class StudentsController : BaseController
    {
        private readonly IStudentsService students;
        private readonly ITeachersService teachers;

        public StudentsController(IStudentsService studentsService, ITeachersService teachersService)
        {
            this.students = studentsService;
            this.teachers = teachersService;
        }

        /// <summary>
        /// Returns all students that arent in any group
        /// </summary>
        /// <returns>ICollection<ApplicationUserViewModel></returns>
        [HttpGet]
        public ICollection<ApplicationUserViewModel> GetGroupAvaiableStudents()
        {
            var avaiableStudents = students.GetGroupAvaiableStudents().ToList();
            var studentsViewModel = Mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(avaiableStudents);

            return studentsViewModel;
        }

        /// <summary>
        /// Adds student to the current teacher
        /// </summary>
        /// <param name="id">The id of the student</param>
        /// <returns>200 Ok if added</returns>
        [HttpPost]
        public IHttpActionResult AddStudentToGroup(string id)
        {
            var teacherId = User.Identity.GetUserId();
            var teacher = teachers.Get(teacherId);
            var student = students.GetAll().FirstOrDefault(s => s.UserName == id);
            if (teacher == null || student == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            this.students.AddStudentToGroup(teacher, student);
            return Ok();
        }
    }
}