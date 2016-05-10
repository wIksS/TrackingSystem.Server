namespace TrackingSystem.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.ViewModels;
    using TrackingSystem.Common.Mapping;

    [Authorize]
    public class LocationController : BaseController
    {
        private readonly ILocationService locations;
        private readonly IUsersService users;

        public LocationController(ILocationService locationsService, IUsersService usersService)
        {
            this.locations = locationsService;
            this.users = usersService;
        }

        /// <summary>
        /// Returns the last location for the specified user
        /// </summary>
        /// <param name="id"> The id of the user</param>
        /// <returns> CoordinatesViewModel</returns>
        [HttpGet]
        public CoordinatesViewModel GetLocation(string id)
        {
            string userName = id;
            ApplicationUser user = users.GetByUserName(userName);          
            if (user != null && user.Coordinates.Count == 0)
            {
                return null;
            }

            var coordinate = locations.Get(user);
            var coordinateViewModel = Mapper.Map<CoordinatesViewModel>(coordinate);

            return coordinateViewModel;
        }

        /// <summary>
        /// Adds new location for the current user and returns responce if someone is too distant from the current one
        /// </summary>
        /// <param name="coordinate"> the current location</param>
        /// <returns>ICollection<DistanceViewModel></returns>
        [HttpPost]
        public ICollection<DistanceViewModel> AddLocation(CoordinatesViewModel coordinate)
        {
            if (coordinate == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            var userId = User.Identity.GetUserId();
            ApplicationUser user = users.Get(userId);

            var dbCoordinate = Mapper.Map<Coordinate>(coordinate);
            locations.AddCoodinate(dbCoordinate,user);
            var distancesViewModel = locations.GetDistantUsers(user)
                                     .AsQueryable()
                                     .To<DistanceViewModel>()
                                     .ToList();            

            return distancesViewModel;
        }
    }
}
