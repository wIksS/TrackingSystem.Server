using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackingSystem.ViewModels
{
    public class TeacherViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string ImageUrl { get; set; }

        public bool? IsInExcursion { get; set; }
    }
}