namespace TrackingSystem.Common
{
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculates the distance between two points using the build in C# location api
        /// </summary>
        /// <param name="lat1">First latitude</param>
        /// <param name="lat2"> Second latitude</param>
        /// <param name="long1"> First longitude</param>
        /// <param name="long2"> Second longitude</param>
        /// <returns>double</returns>
        double Calculate(double lat1, double lat2, double long1, double long2);
    }
}
