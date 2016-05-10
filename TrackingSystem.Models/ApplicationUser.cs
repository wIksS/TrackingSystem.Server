namespace TrackingSystem.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public abstract class ApplicationUser : IdentityUser
    {
        private ICollection<Coordinate> coordinates;
        private ICollection<Event> events;

        public ApplicationUser()
        {
            this.Events = new HashSet<Event>();
            this.Coordinates = new HashSet<Coordinate>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public bool? IsInExcursion
        {
            get;
            set;
        }

        public virtual Group Group
        {
            get;
            set;
        }

        public int? GroupId
        {
            get;
            set;
        }

        public virtual ICollection<Coordinate> Coordinates
        {
            get
            {
                return this.coordinates;
            }
            set
            {
                this.coordinates = value;
            }
        }

        public virtual ICollection<Event> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
            }
        }
    }
}
