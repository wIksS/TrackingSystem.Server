using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.Data;
using TrackingSystem.Models;
using TrackingSystem.Services.Contracts;

namespace TrackingSystem.Services
{
    public class EventsService : IEventsService
    {
        private readonly ITrackingSystemData data;

        public EventsService(ITrackingSystemData data)
        {
            this.data = data;
        }

        public void Add(string teacherId, Event eventModel)
        {
            Teacher teacher = data.Teachers.Find(teacherId);

            data.Events.Add(eventModel);
            data.Events.SaveChanges();

            var group = teacher.Group;
            foreach (var student in group.Students)
            {
                student.Events.Add(eventModel);
            }

            data.Students.SaveChanges();
        }
    }
}
