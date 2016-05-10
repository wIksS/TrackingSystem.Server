namespace TrackingSystem.Services.Contracts
{
    using System.Collections.Generic;
    using TrackingSystem.Models;

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

        /// <summary>
        /// Calculates the distance to the user
        /// </summary>
        /// <returns>IEnumerable<DistanceModel></returns>
        IEnumerable<DistanceModel> CalculateDistance(ApplicationUser user);

    }
}
