using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Models
{
    public class Coordinate
    {
        public int Id
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public virtual ApplicationUser User
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

        public int Heading
        {
            get;
            set;
        }
    }
}
