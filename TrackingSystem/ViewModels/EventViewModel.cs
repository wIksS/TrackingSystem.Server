using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingSystem.ViewModels
{
    public class EventViewModel
    {
        public DateTime Date { get; set; }

        public string Message { get; set; }

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
