namespace TrackingSystem.Services.Contracts
{
    using TrackingSystem.Models;

    public interface IFilesService
    {
        /// <summary>
        /// Returns the image of an user or a default image
        /// </summary>
        /// <param name="user"> the user to return</param>
        /// <returns>The path to the image</returns>
        string GetUserImage(ApplicationUser user);

        /// <summary>
        /// Saves the current path to the user
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="filePath">The image path to save</param>
        void SaveImage(ApplicationUser user, string filePath);
    }
}
