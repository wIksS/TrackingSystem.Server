using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingSystem.Data;
using TrackingSystem.Models;

namespace TrackingSystem.Helpers
{
    public static class LocationDistanceDistributor
    {
        public static IEnumerable<KeyValuePair<string,double>> CheckUserDistance(ITrackingSystemData data, ApplicationUser user)
        {
            var users = data.Students.All().Where(u => u.Id != user.Id).ToList();
            var userCoordinate = user.Coordinates.Last();

            for (int i = 0; i < users.Count; i++)
			{
                if (users[i].Coordinates.Count > 0)
                {
                    var currentUserCoordinate = users[i].Coordinates.Last();
                    var distance = DistanceCalculator.Calculate(userCoordinate, currentUserCoordinate);

                    yield return new KeyValuePair<string, double>(users[i].Id, distance);   
                }               
			}
        }
    }
}