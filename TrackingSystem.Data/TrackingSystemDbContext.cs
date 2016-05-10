namespace TrackingSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TrackingSystem.Data.Migrations;
    using TrackingSystem.Models;

    public class TrackingSystemDbContext : IdentityDbContext
    {
        public TrackingSystemDbContext()
            : base("TrackingSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrackingSystemDbContext, Configuration>());
        }

        IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        IDbSet<Student> Students
        {
            get;
            set;
        }

        IDbSet<Teacher> Teachers
        {
            get;
            set;
        }

        IDbSet<Group> Groups
        {
            get;
            set;
        }

        IDbSet<Coordinate> Coordinates
        {
            get;
            set;
        }

        IDbSet<Event> Events
        {
            get;
            set;
        }

        public static TrackingSystemDbContext Create()
        {
            return new TrackingSystemDbContext();
        }
    }
}
