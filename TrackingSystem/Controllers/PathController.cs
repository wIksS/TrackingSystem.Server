using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackingSystem.Models;
using TrackingSystem.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace TrackingSystem.Controllers
{
    public class PathController : BaseController
    {
        [HttpGet]
        public ICollection<CoordinatesViewModel> GetLocation(string id)
        {
            string userName = id;
            ApplicationUser user;

            if (Data.Students.All().Any(s => s.UserName == userName))
            {
                user = Data.Students.All().First(s => s.UserName == userName);
            }
            else
            {
                user = Data.Teachers.All().First(t =>   t.UserName == userName);
            }

            var coords = user.Coordinates.AsQueryable().Project().To<CoordinatesViewModel>().ToList();

            return coords;
        }
    }
}
