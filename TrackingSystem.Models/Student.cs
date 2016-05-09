using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Common;

namespace TrackingSystem.Models
{
    public class Student : ApplicationUser
    {
        public override IEnumerable<KeyValuePair<ApplicationUser, double>> CalculateDistance()
        {
            var studentLastCoordinate = this.Coordinates.LastOrDefault();
            Coordinate teacherLastCoordinate = null;
            if (this.Group.Teacher != null)
            {
                teacherLastCoordinate = this.Group.Teacher.Coordinates.LastOrDefault();
            }

            if (studentLastCoordinate != null && teacherLastCoordinate != null)
            {
                var distance = DistanceCalculator.Calculate(studentLastCoordinate.Latitude, teacherLastCoordinate.Latitude,
                                                            studentLastCoordinate.Longitude, teacherLastCoordinate.Longitude);

                yield return new KeyValuePair<ApplicationUser, double>(this.Group.Teacher, distance);
            }
        }
    }
}
