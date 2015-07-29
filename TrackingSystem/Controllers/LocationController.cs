using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Cors;
using TrackingSystem.Data;
using TrackingSystem.ViewModels;
using Microsoft.AspNet.Identity;
using TrackingSystem.Models;
using AutoMapper;
using TrackingSystem.Infrastructure;

namespace TrackingSystem.Controllers
{
    [Authorize]
    public class LocationController : BaseController
    {
        public LocationController()
            : base()
        {
        }

        [HttpPost]
        public CoordinatesViewModel AddLocation(CoordinatesViewModel coordinates)
        {
            if (coordinates == null)
            {
                return null;
            }

            var userId = User.Identity.GetUserId();
            ApplicationUser user = Data.Users.Find(userId);

            var dbCoordiante = Mapper.Map<Coordinate>(coordinates);

            Data.Coordinates.Add(dbCoordiante);
            user.Coordinates.Add(dbCoordiante);
            dbCoordiante.User = user;

            Data.Coordinates.SaveChanges();

            var distances = LocationDistanceDistributor.CheckUserDistance(Data, user).ToList();

            return coordinates;
        }

        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
