namespace TrackingSystem.Services.Contracts
{
    using System.Collections.Generic;
    using TrackingSystem.Models;

    public interface ITeachersService
    {
        /// <summary>
        /// Calculates the distance to the students
        /// </summary>
        /// <returns>IEnumerable<DistanceModel></returns>
        IEnumerable<DistanceModel> CalculateDistance(ApplicationUser user);

        /// <summary>
        /// Returns all teachers
        /// </summary>
        /// <returns>Teacher</returns>
        IEnumerable<Teacher> GetAll();

        /// <summary>
        /// Returns specific teacher
        /// </summary>
        /// <param name="id"> The id of the teacher</param>
        /// <returns></returns>
        Teacher Get(string id);
    }
}
