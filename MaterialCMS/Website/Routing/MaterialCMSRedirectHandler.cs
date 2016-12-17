using System;
using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website.Routing
{
    public class MaterialCMSRedirectHandler : IMaterialCMSRouteHandler
    {
        private readonly IGetWebpageForRequest _webpageForRequest;

        public MaterialCMSRedirectHandler(IGetWebpageForRequest webpageForRequest)
        {
            _webpageForRequest = webpageForRequest;
        }
        public int Priority { get { return 9950; } }
        public bool Handle(RequestContext context)
        {
            Webpage webpage = _webpageForRequest.Get(context);
            if (webpage is Redirect)
            {
                var redirect = (webpage as Redirect);
                string redirectUrl = redirect.RedirectUrl;
                Uri result;
                if (Uri.TryCreate(redirectUrl, UriKind.Absolute, out result))
                {
                    if (redirect.Permanent)
                        context.HttpContext.Response.RedirectPermanent(redirectUrl);
                    else
                        context.HttpContext.Response.Redirect(redirectUrl);
                }
                else
                {
                    if (redirectUrl.StartsWith("/"))
                        redirectUrl = redirectUrl.Substring(1);

                    if (redirect.Permanent)
                        context.HttpContext.Response.RedirectPermanent("~/" + redirectUrl);
                    else
                        context.HttpContext.Response.Redirect("~/" + redirectUrl);
                }
                return true;
            }
            return false;
        }
    }
}