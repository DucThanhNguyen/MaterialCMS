using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website.Routing
{
    public interface IGetWebpageByUrlHistoryForRequest
    {
        Webpage Get(RequestContext context);
    }
}