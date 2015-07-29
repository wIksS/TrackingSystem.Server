using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.Models
{
    public class Student : ApplicationUser
    {
        public virtual Teacher Teacher { get; set; }

        public override KeyValuePair<string, double> CalculateDistance()
        {
            var distance = DistanceCalculator.Calculate(userCoordinate, currentUserCoordinate);
        }
    }
}
