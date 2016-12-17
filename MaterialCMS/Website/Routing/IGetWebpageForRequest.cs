using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website.Routing
{
    public interface IGetWebpageForRequest
    {
        Webpage Get(RequestContext context, string url = null);
    }
}