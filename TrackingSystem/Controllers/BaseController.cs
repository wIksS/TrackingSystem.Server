using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackingSystem.Data;
public class BaseController : ApiController
{
    [AllowAnonymous]
    public HttpResponseMessage Options()
    {
        return new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK
        };
    }
}