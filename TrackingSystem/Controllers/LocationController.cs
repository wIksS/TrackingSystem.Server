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
using TrackingSystem.Helpers;

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
        public ICollection<DistanceViewModel> AddLocation(CoordinatesViewModel coordinates)
        {
            if (coordinates == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            var userId = User.Identity.GetUserId();
            ApplicationUser user;

            if (Data.Students.All().Any(s => s.Id == userId))
            {
                user = Data.Students.Find(userId);
            }
            else
            {
                user = Data.Teachers.Find(userId);
            }

            var dbCoordiante = Mapper.Map<Coordinate>(coordinates);

            Data.Coordinates.Add(dbCoordiante);
            user.Coordinates.Add(dbCoordiante);
            dbCoordiante.User = user;

            Data.Coordinates.SaveChanges();

            var distancesViewModel = new List<DistanceViewModel>();


            if (user.Group != null)
            {
                var distances = user.CalculateDistance();
                foreach (var distance in distances)
                {
                    var currentUser = distance.Key;
                    var calculatedDistance = distance.Value;

                    if (user.Group != currentUser.Group)
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The students and teachers aren't in the same group"));
                    }

                    if (calculatedDistance > user.Group.MaxDistance)
                    {
                        var lastCoordinateViewModel = Mapper.Map<CoordinatesViewModel>(currentUser.Coordinates.Last());
                        distancesViewModel.Add(new DistanceViewModel()
                           {
                               Coordinate = lastCoordinateViewModel,
                               Distance = calculatedDistance,
                               User = Mapper.Map<ApplicationUserViewModel>(currentUser)
                           });
                    }
                }
            }

            return distancesViewModel;
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
