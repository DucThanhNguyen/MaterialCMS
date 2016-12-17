using System.Web.Routing;
using MaterialCMS.Settings;

namespace MaterialCMS.Website.Routing
{
    public class MaterialCMSAdminSSLRedirectHandler : IMaterialCMSRouteHandler
    {
        private readonly SiteSettings _siteSettings;

        public MaterialCMSAdminSSLRedirectHandler(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public int Priority { get { return 1040; } }
        public bool Handle(RequestContext context)
        {
            var url = context.HttpContext.Request.Url;
            var scheme = url.Scheme;
            if (CurrentRequestData.CurrentUserIsAdmin && _siteSettings.SSLAdmin && _siteSettings.SiteIsLive && !context.HttpContext.Request.IsLocal)
            {
                if (scheme == "http")
                {
                    var redirectUrl = url.ToString().Replace(scheme + "://", "https://");
                    context.HttpContext.Response.Redirect(redirectUrl);
                    return true;
                }
                return false;
            }
            if (CurrentRequestData.CurrentUserIsAdmin && scheme == "http" && _siteSettings.SSLAdmin && _siteSettings.SiteIsLive && !context.HttpContext.Request.IsLocal)
            {
                var redirectUrl = url.ToString().Replace(scheme + "://", "https://");
                context.HttpContext.Response.Redirect(redirectUrl);
                return true;
            }
            return false;
        }
    }
}