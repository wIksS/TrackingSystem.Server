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
        IRepository<ApplicationUser> Users { get; }        

    }
}
