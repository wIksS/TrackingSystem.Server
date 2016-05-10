namespace TrackingSystem.Services.Contracts
{
    using TrackingSystem.Models;

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
