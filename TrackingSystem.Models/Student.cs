using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Helpers;

namespace TrackingSystem.Models
{
    public class Student : ApplicationUser
    {
        public virtual Teacher Teacher { get; set; }

        public int TeacherId { get; set; }

        public override IEnumerable<KeyValuePair<ApplicationUser, double>> CalculateDistance()
        {
            var studentLastCoordinate = this.Coordinates.Last();
            var teacherLastCoordinate = Teacher.Coordinates.Last();

            if (studentLastCoordinate != null && teacherLastCoordinate != null)
            {
                var distance = DistanceCalculator.Calculate(studentLastCoordinate.Latitude, teacherLastCoordinate.Latitude,
                                                            studentLastCoordinate.Longitude, teacherLastCoordinate.Longitude);

                yield return new KeyValuePair<ApplicationUser, double>(this.Teacher, distance);
            }

        }
    }
}
