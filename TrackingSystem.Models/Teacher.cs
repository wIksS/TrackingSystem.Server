using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Common;

namespace TrackingSystem.Models
{
    public class Teacher : ApplicationUser
    {
        public override IEnumerable<KeyValuePair<ApplicationUser, double>> CalculateDistance()
        {
            var teacherLastCoordinate = this.Coordinates.LastOrDefault();
            if (teacherLastCoordinate != null)
            {
                foreach (var student in this.Group.Students)
                {
                    var studentLastCoordinate = student.Coordinates.LastOrDefault();

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
