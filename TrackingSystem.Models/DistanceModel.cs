using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Models
{
    public class DistanceModel
    {
        public Coordinate Coordinate
        {
            get;
            set;
        }

        public double Distance
        {
            get;
            set;
        }

        public ApplicationUser User
        {
            get;
            set;
        }
    }
}
