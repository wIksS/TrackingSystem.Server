using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Data;
using TrackingSystem.Models;
using TrackingSystem.Services.Contracts;

namespace TrackingSystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly ITrackingSystemData data;

        public UsersService(ITrackingSystemData data)
        {
            this.data = data;
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
    }
}
