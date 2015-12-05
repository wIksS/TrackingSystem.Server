using Microsoft.AspNet.Identity.EntityFramework;
using TrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Data.Migrations;

namespace TrackingSystem.Data
{
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
