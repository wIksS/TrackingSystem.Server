namespace TrackingSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        private ICollection<ApplicationUser> users;

        public Event()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public int Id
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public DateTime Date
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
        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }
    }
}