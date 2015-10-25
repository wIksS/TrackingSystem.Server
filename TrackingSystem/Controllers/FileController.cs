using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TrackingSystem.Models;
using Microsoft.AspNet.Identity;
using System.Net.Http.Headers;
using TrackingSystem.Infrastructure;

namespace TrackingSystem.Controllers
{
    [Authorize]
    public class FileController : BaseController
    {
        public FileController()
            : base()
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            string userName = id;
            ApplicationUser user;

            if (Data.Students.All().Any(s => s.UserName == userName))
            {
                user = Data.Students.All().First(s => s.UserName == userName);
            }
            else
            {
                user = Data.Teachers.All().First(t => t.UserName == userName);
            }

            string fileName;

            if (user.ImageUrl != null)
            {
                fileName = user.ImageUrl;
            }
            else
            {
                fileName = HttpContext.Current.Server.MapPath(AppConstants.UnkownImagePath);
            }

            if (!File.Exists(fileName))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            HttpResponseMessage response = new HttpResponseMessage { Content = new StreamContent(fileStream) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            response.Content.Headers.ContentLength = fileStream.Length;

            return response;                
        }

        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["IMG_Upload"];

                if (httpPostedFile != null)
                {
                    var userId = User.Identity.GetUserId();
                    ApplicationUser user;

                    if (Data.Students.All().Any(s => s.Id == userId))
                    {
                        user = Data.Students.Find(userId);
                    }
                    else
                    {
                        user = Data.Teachers.Find(userId);
                    }

                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), httpPostedFile.FileName + user.UserName + ".jpg");

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);

                    user.ImageUrl = fileSavePath;
                    Data.Students.SaveChanges();
                }
            }
        }

    }
}
