using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Models;

namespace TrackingSystem.Services.Contracts
{
    public interface IUsersService
    {
        /// <summary>
        /// Returns the specific user
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        ApplicationUser Get(string id);

        /// <summary>
        /// Returns user by username. He can be a teacher or a student
        /// </summary>
        /// <param name="userName">The username of the user</param>
        /// <returns>ApplicationUser</returns>
        ApplicationUser GetByUserName(string userName);

    }
}
