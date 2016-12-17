using System.Web.Routing;

namespace MaterialCMS.Website.Routing
{
    public interface IMaterialCMSRouteHandler
    {
        int Priority { get; }
        bool Handle(RequestContext context);
    }
}