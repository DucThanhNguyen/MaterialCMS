using System.Web.Mvc;
using MaterialCMS.Settings;
using MaterialCMS.Website;

namespace MaterialCMS.Helpers
{
    public static class HoneypotHtmlHelper
    {
        public static MvcHtmlString Honeypot(this HtmlHelper html)
        {
            var siteSettings = MaterialCMSApplication.Get<SiteSettings>();

            return siteSettings.HasHoneyPot
                       ? MvcHtmlString.Create(siteSettings.GetHoneypot().ToString())
                       : MvcHtmlString.Empty;
        }
    }
}