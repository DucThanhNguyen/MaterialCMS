using System.Web.Routing;

namespace MaterialCMS.Website.Routing
{
    public class UrlHistoryHandler : IMaterialCMSRouteHandler
    {
        private readonly IGetWebpageForRequest _getWebpage;
        private readonly IGetWebpageByUrlHistoryForRequest _getWebpageByUrlHistory;

        public UrlHistoryHandler(IGetWebpageForRequest getWebpage, IGetWebpageByUrlHistoryForRequest getWebpageByUrlHistory)
        {
            _getWebpage = getWebpage;
            _getWebpageByUrlHistory = getWebpageByUrlHistory;
        }

        public bool Handle(RequestContext context)
        {
            if (_getWebpage.Get(context) != null)
                return false;

            var webpage = _getWebpageByUrlHistory.Get(context);
            if (webpage == null)
                return false;

            context.HttpContext.Response.RedirectPermanent("~/" + webpage.LiveUrlSegment);
            return false;
        }

        public int Priority { get { return 10000; } }
    }
}