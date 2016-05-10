namespace TrackingSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using TrackingSystem.Common;
    using TrackingSystem.Data;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;

    public class TeachersService : ITeachersService
    {
        private readonly ITrackingSystemData data;
        private readonly IDistanceCalculator calculator;

        public TeachersService(ITrackingSystemData data, IDistanceCalculator distanceCalculator)
        {
            this.data = data;
            this.calculator = distanceCalculator;
        }

        public IEnumerable<DistanceModel> CalculateDistance(ApplicationUser user)
        {
            var teacherLastCoordinate = user.Coordinates.LastOrDefault();
            if (teacherLastCoordinate != null)
            {
                foreach (var student in user.Group.Students)
                {
                    var studentLastCoordinate = student.Coordinates.LastOrDefault();

                    if (studentLastCoordinate != null && teacherLastCoordinate != null)
                    {
                        var distance = calculator.Calculate(studentLastCoordinate.Latitude, teacherLastCoordinate.Latitude, studentLastCoordinate.Longitude, teacherLastCoordinate.Longitude);

                        yield return new DistanceModel()
                        {
                            Distance = distance,
                            User = student,
                            Coordinate = teacherLastCoordinate
                        };
                    }
                }
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            var teachers = this.data.Teachers.All();

            return teachers;
        }

        public Teacher Get(string id)
        {
            return data.Teachers.Find(id);
        }        
    }
}
