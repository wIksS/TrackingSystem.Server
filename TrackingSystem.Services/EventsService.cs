namespace TrackingSystem.Services
{
    using TrackingSystem.Data;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;

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
