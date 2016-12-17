using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Services;

namespace MaterialCMS.Website.Routing
{
    public class MaterialCMSHomePageRedirectHandler : IMaterialCMSRouteHandler
    {
        private readonly IGetWebpageForRequest _getWebpageForRequest;
        private readonly IGetHomePage _homePage;

        public MaterialCMSHomePageRedirectHandler(IGetWebpageForRequest getWebpageForRequest, IGetHomePage homePage)
        {
            _getWebpageForRequest = getWebpageForRequest;
            _homePage = homePage;
        }

        public int Priority { get { return 9700; } }
        public bool Handle(RequestContext context)
        {
            Webpage webpage = _getWebpageForRequest.Get(context);
            if (webpage == null)
                return false;
            if (webpage == _homePage.Get() && context.HttpContext.Request.Url.AbsolutePath != "/")
            {
                context.HttpContext.Response.Redirect("~/");
                return true;
            }
            return false;
        }
    }
}