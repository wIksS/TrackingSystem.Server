using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TrackingSystem.ViewModels;
using System.Threading.Tasks;

namespace TrackingSystem.Infrastructure
{
    public class EventHub : Hub
    {        
        public void JoinRoom(string groupName, string userName)
        {
            Groups.Add(Context.ConnectionId, groupName);
            UsersConnections.AddUser(Context.ConnectionId, userName);
        }

        public void LeaveRoom(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }

        public void SendEvent(EventViewModel eventViewModel, string groupName)
        {
            Clients.Group(groupName).receiveEvent(eventViewModel);
        }        
    }
} 
