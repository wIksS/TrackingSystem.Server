namespace TrackingSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using TrackingSystem.Data;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;

    public class UsersService : IUsersService
    {
        private readonly ITrackingSystemData data;
        private readonly ITeachersService teachers;
        private readonly IStudentsService students;

        public UsersService(ITrackingSystemData data, IStudentsService studentsService, ITeachersService teachersService)
        {
            this.data = data;
            this.students = studentsService;
            this.teachers = teachersService;
        }

        public ApplicationUser Get(string id)
        {
            return data.Users.Find(id);
        }

        // User can be both a student and a teacher
        // We have to look in both repositories to find him
        public ApplicationUser GetByUserName(string userName)
        {
            ApplicationUser user;
            if (data.Students.All().Any(s => s.UserName == userName))
            {
                user = data.Students.All().First(s => s.UserName == userName);
            }
            else
            {
                user = data.Teachers.All().First(t => t.UserName == userName);
            }

            return user;
        }

        public IEnumerable<DistanceModel> CalculateDistance(ApplicationUser user)
        {
            if (user is Teacher)
            {
                return teachers.CalculateDistance(user);
            }
            else if(user is Student)
            {
                return students.CalculateDistance(user);
            }
            else
            {
                return null;
            }
        }
    }
}
