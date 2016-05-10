namespace TrackingSystem.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.ViewModels;

    [Authorize]
    [RoutePrefix("api/Group")]
    public class GroupController : BaseController
    {
        private readonly IGroupsService groups;
        private readonly ITeachersService teachers;
        private readonly IStudentsService students;
        private readonly IUsersService users;

        public GroupController(IGroupsService groupsService, IStudentsService studentsService, IUsersService usersService, ITeachersService teachersService)
        {
            this.groups = groupsService;
            this.students = studentsService;
            this.users = usersService;
            this.teachers = teachersService;
        }

        /// <summary>
        /// Changes the group distance. Users will be notified using the new distance
        /// </summary>
        /// <param name="newDistance"> The new distance to be notified to</param>
        /// <returns> The updated groupViewModel</returns>
        [HttpPost]
        public IHttpActionResult ChangeGroupDistance([FromUri]int newDistance)
        {
            var userId = User.Identity.GetUserId();

            if (teachers.GetAll().FirstOrDefault(t => t.Id == userId) == null)
            {
                return BadRequest("You can set the tracking distance only for a teacher");
            }

            var group = groups.ChangeDistance(newDistance, userId);
            var groupViewModel = Mapper.Map<GroupViewModel>(group);

            return Ok(groupViewModel);
        }

        /// <summary>
        /// Returns all students in the group of the teacher
        /// </summary>
        /// <param name="id"> Optional specify which user's group you want. The default is the logged user</param>
        /// <returns> All students in the group</returns>
        [Route("GetStudentsInGroup")]
        public ICollection<ApplicationUserViewModel> GetStudentsInGroup(string id = null)
        {
            var userId = id;
            if (userId == null)
            {
                userId = User.Identity.GetUserId();
            }

            ApplicationUser user = users.Get(userId);
            if (user == null || user.Group == null)
            {
                return null;
            }

            var students = user.Group.Students.Cast<ApplicationUser>().ToList();
            var studentsViewModel = Mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(students);

            return studentsViewModel;
        }

        /// <summary>
        /// Removes student from group
        /// </summary>
        /// <param name="id">The id of the user group</param>
        /// <returns>Ok if removed</returns>
        [Route("RemoveFromGroup")]
        public IHttpActionResult RemoveFromGroup([FromUri]string id)
        {
            string userName = id;
            Student user = students.GetAll().First(s => s.UserName == userName);          
            if (user == null)
            {
                return NotFound();
            }

            if (user.Group != null)
            {
                groups.RemoveFromGroup(user);
            }

            return Ok();
        }

        /// <summary>
        /// Returns the group of the current user
        /// </summary>
        /// <returns>GroupViewModel</returns>
        [Route("GetGroup")]
        public GroupViewModel GetGroup()
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser user;
            bool isTeacher = false;

            if (students.GetAll().Any(s => s.Id == userId))
            {
                user = students.Get(userId);
            }
            else
            {
                user = teachers.Get(userId);
                isTeacher = true;
            }

            var group = user.Group;
            if (group == null && isTeacher)
            {
                group = groups.CreateGroup(user);
            }

            var groupViewModel = Mapper.Map<GroupViewModel>(group);

            return groupViewModel;
        }
    }
}
