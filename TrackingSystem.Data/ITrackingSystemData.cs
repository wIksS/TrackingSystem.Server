namespace TrackingSystem.Data
{
    using TrackingSystem.Data.Repositories;
    using TrackingSystem.Models;

    public interface ITrackingSystemData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Teacher> Teachers
        {
            get;
        }

        IRepository<Student> Students
        {
            get;
        }

        IRepository<Group> Groups
        {
            get;
        }

        IRepository<Coordinate> Coordinates
        {
            get;
        }

        IRepository<Event> Events
        {
            get;
        }

    }
}
