namespace TrackingSystem.Services
{
    using TrackingSystem.Common;
    using TrackingSystem.Data;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;

    public class GroupsService : IGroupsService
    {
        private readonly ITrackingSystemData data;

        public GroupsService(ITrackingSystemData data)
        {
            this.data = data;
        }

        public Group ChangeDistance(int newDistance, string userId)
        {
            ApplicationUser user = data.Teachers.Find(userId);
            var group = user.Group;

            group.MaxDistance = newDistance;
            this.data.Groups.SaveChanges();

            return group;
        }

        public void RemoveFromGroup(Student user)
        {
            var group = user.Group;

            user.Group = null;
            user.GroupId = null;

            group.Students.Remove(user);
            data.Students.SaveChanges();
        }

        public Group CreateGroup(ApplicationUser user)
        {
            var group = new Group()
            {
                MaxDistance = AppConstants.MaxDistance,
                Teacher = user as Teacher,
                TeacherId = user.Id
            };

            this.data.Groups.Add(group);
            user.Group = group;
            this.data.Groups.SaveChanges();

            return group;
        }
    }
}
