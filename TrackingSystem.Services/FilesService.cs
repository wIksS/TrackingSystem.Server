namespace TrackingSystem.Services
{
    using TrackingSystem.Data;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;

    public class FilesService : IFilesService
    {
        private readonly ITrackingSystemData data;

        public FilesService(ITrackingSystemData data)
        {
            this.data = data;
        }

        public string GetUserImage(ApplicationUser user)
        {
            string fileName = null;
            if (user.ImageUrl != null)
            {
                fileName = user.ImageUrl;
            }

            return fileName;
        }

        public void SaveImage(ApplicationUser user, string filePath)
        {
            user.ImageUrl = filePath;
            data.Users.SaveChanges();
        }
    }
}
