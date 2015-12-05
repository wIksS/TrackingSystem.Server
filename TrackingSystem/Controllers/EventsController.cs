using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackingSystem.Models;
using TrackingSystem.ViewModels;
using Microsoft.AspNet.Identity;
using AutoMapper;
using Microsoft.AspNet.SignalR;
using TrackingSystem.Infrastructure;

namespace TrackingSystem.Controllers
{
    [System.Web.Http.Authorize]
    public class EventsController : BaseController
    {
        public EventsController()
            : base()
        {
        }


        [HttpPost]
        public IHttpActionResult AddEvent(EventViewModel eventViewModel)
        {
            if (eventViewModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState));
            }

            var teacherId = User.Identity.GetUserId();
            Teacher teacher = Data.Teachers.Find(teacherId);

            var dbEvent = Mapper.Map<Event>(eventViewModel);
            Data.Events.Add(dbEvent);
            Data.Events.SaveChanges();

            var group = teacher.Group;
            foreach (var student in group.Students)
            {
                student.Events.Add(dbEvent);
            }

            Data.Students.SaveChanges();

            SendEvent(eventViewModel,teacher.GroupId.ToString(),teacher.UserName);

            return Ok();
        }

        private void SendEvent(EventViewModel eventViewModel,string groupName, string clientUserName)
        {
            GlobalHost
           .ConnectionManager
           .GetHubContext<EventHub>().Clients.Group(groupName, UsersConnections.GetUserConnection(clientUserName)).receiveEvent(eventViewModel);
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