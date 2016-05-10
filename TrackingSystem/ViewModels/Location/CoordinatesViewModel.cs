namespace TrackingSystem.ViewModels
{
    using System;
    using TrackingSystem.Common.Mapping;
    using TrackingSystem.Models;

    public class CoordinatesViewModel : IMapFrom<Coordinate>
    {
        public DateTime Date
        {
            get;
            set;
        }

        public double Accuracy
        {
            get;
            set;
        }

        public double Altitude
        {
            get;
            set;
        }

        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }

        public double Speed
        {
            get;
            set;
        }

        public double AltitudeAccuracy
        {
            get;
            set;
        }

        public int? Heading
        {
            get;
            set;
        }
    }
}