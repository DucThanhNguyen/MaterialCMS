using System;
using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Models;
using MaterialCMS.Website.Caching;

namespace MaterialCMS.Services.Caching
{
    public class HtmlCacheService : IHtmlCacheService
    {
        private readonly ICacheManager _cacheManager;

        public HtmlCacheService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public ActionResult GetContent(Controller controller, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func)
        {
            return _cacheManager.Get(cachingInfo.CacheKey, () => new ContentResult
            {
                Content = func(controller.GetHtmlHelper()).ToString()
            }, cachingInfo.ShouldCache ? cachingInfo.TimeToCache : TimeSpan.Zero, cachingInfo.ExpiryType);
        }

        public MvcHtmlString GetString(Controller controller, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func)
        {
            return _cacheManager.Get(cachingInfo.CacheKey, () => func(controller.GetHtmlHelper()),
                cachingInfo.ShouldCache ? cachingInfo.TimeToCache : TimeSpan.Zero, cachingInfo.ExpiryType);
        }

        public ActionResult GetContent(HtmlHelper helper, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func)
        {
            return _cacheManager.Get(cachingInfo.CacheKey, () => new ContentResult
            {
                Content = func(helper).ToString()
            }, cachingInfo.ShouldCache ? cachingInfo.TimeToCache : TimeSpan.Zero, cachingInfo.ExpiryType);
        }

        public MvcHtmlString GetString(HtmlHelper helper, CachingInfo cachingInfo, Func<HtmlHelper, MvcHtmlString> func)
        {
            return _cacheManager.Get(cachingInfo.CacheKey, () => func(helper),
                cachingInfo.ShouldCache ? cachingInfo.TimeToCache : TimeSpan.Zero, cachingInfo.ExpiryType);
        }
    }
}