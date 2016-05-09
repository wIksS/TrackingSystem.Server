namespace TrackingSystem.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Http;
    using TrackingSystem.Common;
    using TrackingSystem.Models;
    using TrackingSystem.Services.Contracts;

    [Authorize]
    public class FileController : BaseController
    {
        private readonly IFilesService files;
        private readonly IUsersService users;

        public FileController(IFilesService filesService, IUsersService usersService)
        {
            this.files = filesService;
            this.users = usersService;
        }

        /// <summary>
        /// Returns the image of the currentUser
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns> The image as response</returns>
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            if (id == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            string userName = id;
            ApplicationUser user = users.GetByUserName(userName);
            string fileName = files.GetUserImage(user);
            if (!File.Exists(fileName))
            {
                fileName = HttpContext.Current.Server.MapPath(AppConstants.UnkownImagePath);
            }
           
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            HttpResponseMessage response = new HttpResponseMessage { Content = new StreamContent(fileStream) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentLength = fileStream.Length;

            return response;                
        }

        /// <summary>
        /// Adds the image file to the current user
        /// </summary>
        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["IMG_Upload"];

                if (httpPostedFile != null)
                {
                    var userName = User.Identity.GetUserName();
                    ApplicationUser user = users.GetByUserName(userName);

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), httpPostedFile.FileName + user.UserName + ".jpg");

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    files.SaveImage(user,fileSavePath);
                }
            }
        }

    }
}
