namespace TrackingSystem.Services.Contracts
{
    using System.Collections.Generic;
    using TrackingSystem.Models;

    public interface IStudentsService
    {
        /// <summary>
        /// Calculates the distance to the teacher
        /// </summary>
        /// <returns>IEnumerable<DistanceModel></returns>
        IEnumerable<DistanceModel> CalculateDistance(ApplicationUser user);

        /// <summary>
        /// Returns all students that arent currently in any group
        /// </summary>
        /// <returns>ApplicationUser</returns>
        ICollection<ApplicationUser> GetGroupAvaiableStudents();

        /// <summary>
        ///  Adds Student to specific group
        /// </summary>
        /// <param name="teacher"> The teacher to add the student</param>
        /// <param name="student"> The student to be added</param>
        void AddStudentToGroup(Teacher teacher, Student student);

        /// <summary>
        /// Returns the specific student
        /// </summary>
        /// <param name="id">The id of the student</param>
        /// <returns></returns>
        Student Get(string id);

        /// <summary>
        /// Returns all students
        /// </summary>
        /// <returns>All students</returns>
        IEnumerable<Student> GetAll();
    }
}
