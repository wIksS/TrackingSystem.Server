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
    public class LocationService : ILocationService
    {
        private readonly ITrackingSystemData data;

        public LocationService(ITrackingSystemData data)
        {
            this.data = data;
        }

        public Coordinate Get(ApplicationUser user)
        {
            return user.Coordinates.Last();
        }

        public void AddCoodinate(Coordinate coordinate, ApplicationUser user)
        {
            user.IsInExcursion = true;
            coordinate.Date = DateTime.Now;

            data.Coordinates.Add(coordinate);
            user.Coordinates.Add(coordinate);
            coordinate.User = user;

            data.Coordinates.SaveChanges();
        }

        public IEnumerable<DistanceModel> GetDistantUsers(ApplicationUser user)
        {
            var distancesList = new List<DistanceModel>();
            if (user.Group != null)
            {
                var distances = user.CalculateDistance().ToList();
                foreach (var distance in distances)
                {
                    var currentUser = distance.Key;
                    var calculatedDistance = distance.Value;

                    if (user.Group != currentUser.Group)
                    {
                        throw new ArgumentException("The students and teachers aren't in the same group");
                    }

                    if (!user.IsInExcursion == false || !currentUser.IsInExcursion == false)
                    {
                        if (calculatedDistance > user.Group.MaxDistance)
                        {
                            var lastCoordinate = currentUser.Coordinates.Last();
                            distancesList.Add(new DistanceModel()
                            {
                                Coordinate = lastCoordinate,
                                Distance = calculatedDistance,
                                User = currentUser
                            });
                        }
                    }
                }
            }

            return distancesList;
        }
    }
}
