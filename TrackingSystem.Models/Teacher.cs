using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Helpers;

namespace TrackingSystem.Models
{
    public class Teacher : ApplicationUser
    {
        private ICollection<Student> students;

        public Teacher()
        {
            this.Students = new HashSet<Student>();
        }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public override IEnumerable<KeyValuePair<ApplicationUser, double>> CalculateDistance()
        {
            var teacherLastCoordinate = this.Coordinates.Last();
            if (teacherLastCoordinate != null)
            {
                foreach (var student in this.Students)
                {
                    var studentLastCoordinate = student.Coordinates.Last();

                    if (studentLastCoordinate != null && teacherLastCoordinate != null)
                    {
                        var distance = DistanceCalculator.Calculate(studentLastCoordinate.Latitude, teacherLastCoordinate.Latitude,
                                                                    studentLastCoordinate.Longitude, teacherLastCoordinate.Longitude);

                        yield return new KeyValuePair<ApplicationUser, double>(student, distance);
                    }
                }
            }
        }
    }
}
