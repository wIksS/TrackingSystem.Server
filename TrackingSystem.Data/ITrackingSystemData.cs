using TrackingSystem.Data.Repositories;
using TrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackingSystem.Data
{
    public interface ITrackingSystemData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Teacher> Teachers
        {
            get;
        }

        IRepository<Student> Students
        {
            get;
        }

        IRepository<Group> Groups
        {
            get;
        }

        IRepository<Coordinate> Coordinates
        {
            get;
        }

    }
}
