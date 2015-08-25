using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackingSystem.Data;
public class BaseController : ApiController
{
    public BaseController()
        : this(new TrackingSystemData())
    {
    }

    public BaseController(ITrackingSystemData data)
    {
        this.Data = data;
    }

    protected ITrackingSystemData Data
    {
        get;
        set;
    }
}