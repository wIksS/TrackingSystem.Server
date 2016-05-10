namespace TrackingSystem.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.ViewModels;
    using TrackingSystem.Common.Mapping;

    [Authorize]
    public class PathController : BaseController
    {
        private readonly IUsersService users;

        public PathController(IUsersService usersService)
        {
            this.users = usersService;
        }

        /// <summary>
        /// Returns all locations for specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ICollection<CoordinatesViewModel> GetLocation(string id)
        {
            string userName = id;
            ApplicationUser user = users.GetByUserName(userName);

            var coords = user.Coordinates.AsQueryable().To<CoordinatesViewModel>().ToList();
            return coords;
        }
    }
}
