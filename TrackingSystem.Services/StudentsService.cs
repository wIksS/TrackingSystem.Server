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
    public class StudentsService : IStudentsService
    {
        private readonly ITrackingSystemData data;

        public StudentsService(ITrackingSystemData data)
        {
            this.data = data;
        }

        public void AddStudentToGroup(Teacher teacher, Student student)
        {
            if (teacher.Group == null)
            {
                var group = new Group();
                group.Teacher = teacher;

                data.Groups.Add(group);
                data.Groups.SaveChanges();
                teacher.Group = group;
            }

            teacher.Group.Students.Add(student);
            student.Group = teacher.Group;
            data.Groups.SaveChanges();
        }

        public ICollection<ApplicationUser> GetGroupAvaiableStudents()
        {
            var students = data.Students.All().
                           Where(s => s.GroupId == null).
                           Cast<ApplicationUser>().ToList();

            return students;
        }

        public Student Get(string id)
        {
            return data.Students.Find(id);
        }


        public IEnumerable<Student> GetAll()
        {
            return data.Students.All();
        }
    }
}
