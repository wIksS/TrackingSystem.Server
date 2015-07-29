using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingSystem.Models;
using System.Device.Location;

namespace TrackingSystem.Infrastructure
{
    public static class DistanceCalculator
    {
        public static double Calculate(Coordinate firstCoord, Coordinate secondCoord)
        {
            var geoCoordFirst = new GeoCoordinate(firstCoord.Latitude, firstCoord.Longitude);
            var geoCoordSecond = new GeoCoordinate(secondCoord.Latitude, secondCoord.Longitude);

            var distance = geoCoordFirst.GetDistanceTo(geoCoordSecond);
         
           // return distance;

            var R = 6371000; // earths diameter metres
            var lat1 = DegreeToRadian(firstCoord.Latitude);
            var lat2 = DegreeToRadian(secondCoord.Latitude);
            var deltaLat = DegreeToRadian(secondCoord.Latitude - firstCoord.Latitude);
            var deltaLong = DegreeToRadian(secondCoord.Longitude - firstCoord.Longitude);

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(firstCoord.Latitude) * Math.Cos(secondCoord.Latitude) *
                    Math.Sin(deltaLong / 2) * Math.Sin(deltaLong / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            distance = R * c;

            return distance;
        }

        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}