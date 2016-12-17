using System.Web;
using System.Web.Routing;

namespace MaterialCMS.Website.Routing
{
    public interface IMaterialCMSRoutingErrorHandler
    {
        void HandleError(RequestContext context, int code, HttpException exception);
    }
}