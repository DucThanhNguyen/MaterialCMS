using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaterialCMS.Website.Routing
{
    public class MaterialCMSRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return CurrentRequestData.DatabaseIsInstalled
                ? (IHttpHandler) MaterialCMSApplication.Get<MaterialCMSHttpHandler>()
                : new NotInstalledHandler();
        }
    }
}