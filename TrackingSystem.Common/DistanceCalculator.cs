namespace TrackingSystem.Common
{
    using System.Device.Location;

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