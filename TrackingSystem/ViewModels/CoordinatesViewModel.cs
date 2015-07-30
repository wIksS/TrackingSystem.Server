using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingSystem.ViewModels
{
    public class CoordinatesViewModel
    {   
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

        public int?  Heading
        {
            get;
            set;
        }
    }
}