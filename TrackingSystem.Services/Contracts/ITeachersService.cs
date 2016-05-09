using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Models;

namespace TrackingSystem.Services.Contracts
{
    public interface ITeachersService
    {
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
