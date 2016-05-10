namespace TrackingSystem.Controllers
{
    using AutoMapper;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using TrackingSystem.Common.Mapping;

    public class BaseController : ApiController
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}