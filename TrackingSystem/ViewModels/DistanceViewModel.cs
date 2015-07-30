using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingSystem.Models;

namespace TrackingSystem.ViewModels
{
    public class DistanceViewModel
    {
        public CoordinatesViewModel Coordinate { get; set; }

        public double Distance { get; set; }

        public ApplicationUserViewModel User { get; set; }
    }
}