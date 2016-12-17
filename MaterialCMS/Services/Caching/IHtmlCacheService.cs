using System;
using System.Web.Mvc;
using MaterialCMS.Models;
using MaterialCMS.Website;

namespace MaterialCMS.Services.Caching
{
    public interface IHtmlCacheService
    {
        ActionResult GetContent(Controller controller, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func);
        MvcHtmlString GetString(Controller controller, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func);
        ActionResult GetContent(HtmlHelper helper, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func);
        MvcHtmlString GetString(HtmlHelper helper, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func);
    }

    public static class HtmlCacheExtensions
    {
        public static MvcHtmlString GetCached(this HtmlHelper helper, CachingInfo cachingInfo,
            Func<HtmlHelper, MvcHtmlString> func)
        {
            return MaterialCMSApplication.Get<IHtmlCacheService>().GetString(helper, cachingInfo, func);
        }
    }
}