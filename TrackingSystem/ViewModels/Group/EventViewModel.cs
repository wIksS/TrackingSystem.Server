namespace TrackingSystem.ViewModels
{
    using System;
    using TrackingSystem.Common.Mapping;
    using TrackingSystem.Models;

    public class EventViewModel : IMapFrom<Event>
    {
        public DateTime Date
        {
            get;
            set;
        }

        public string Message
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
    }
}
