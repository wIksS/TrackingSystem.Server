namespace TrackingSystem.Services.Contracts
{
    using TrackingSystem.Models;

    public interface IGroupsService
    {
        /// <summary>
        /// Changes the distance to be notified of the group 
        /// </summary>
        /// <param name="newDistance"> the new distance</param>
        /// <param name="userId"> the user id to change the distance</param>
        /// <returns>The new Group Model</returns>
        Group ChangeDistance(int newDistance, string userId);

        /// <summary>
        /// Removes the student from the group
        /// </summary>
        /// <param name="user">the User</param>
        void RemoveFromGroup(Student user);

        /// <summary>
        /// Creates the group for an user
        /// </summary>
        /// <param name="user"> the user</param>
        /// <returns>The Group</returns>
        Group CreateGroup(ApplicationUser user);
    }
}
