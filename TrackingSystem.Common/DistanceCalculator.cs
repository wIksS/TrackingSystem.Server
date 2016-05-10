using System;
using System.Device.Location;

namespace TrackingSystem.Common
{
    //TODO: instanced class ninject
    //TODO: Services for teacher and student
    public class DistanceCalculator : IDistanceCalculator
    {
        public double Calculate(double lat1, double lat2, double long1, double long2)
        {
            var geoCoordFirst = new GeoCoordinate(lat1, long1);
            var geoCoordSecond = new GeoCoordinate(lat2, long2);

            var distance = geoCoordFirst.GetDistanceTo(geoCoordSecond);

            return distance;
        }
    }
}