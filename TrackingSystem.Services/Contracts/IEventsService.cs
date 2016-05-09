using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Models;

namespace TrackingSystem.Services.Contracts
{
    public interface IEventsService
    {
        /// <summary>
        /// Adds event
        /// </summary>
        /// <param name="teacherId">The teacher who is adding the event</param>
        /// <param name="eventModel">The event model</param>
 
        void Add(string teacherId, Event eventModel);
    }
}
