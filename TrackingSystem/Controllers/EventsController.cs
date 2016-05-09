namespace TrackingSystem.Controllers
{
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.SignalR;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using TrackingSystem.Infrastructure;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;
    using TrackingSystem.ViewModels;

    [System.Web.Http.Authorize]
    public class EventsController : BaseController
    {
        private readonly IEventsService events;
        private readonly ITeachersService teachers;

        public EventsController(IEventsService eventsService, ITeachersService teachersService)
        {
            this.events = eventsService;
            this.teachers = teachersService;
        }

        /// <summary>
        /// Creates an event and notifies all users in the group
        /// </summary>
        /// <param name="eventViewModel">the viewModel of the event</param>
        /// <returns>200 Ok if event is created</returns>
        [HttpPost]
        public IHttpActionResult AddEvent(EventViewModel eventViewModel)
        {
            if (eventViewModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            var teacherId = User.Identity.GetUserId();
            var dbEvent = Mapper.Map<Event>(eventViewModel);
            events.Add(teacherId, dbEvent);

            var teacher = teachers.Get(teacherId);
            SendEvent(eventViewModel, teacher.GroupId.ToString(), teacher.UserName);

            return Ok();
        }

        private void SendEvent(EventViewModel eventViewModel, string groupName, string clientUserName)
        {
            GlobalHost
           .ConnectionManager
           .GetHubContext<EventHub>().Clients.Group(groupName, UsersConnections.GetUserConnection(clientUserName)).receiveEvent(eventViewModel);
        }
    }
}