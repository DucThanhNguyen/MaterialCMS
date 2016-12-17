using System.Web.Mvc;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Services.Sitemaps;
using MaterialCMS.Website.Controllers;
using MaterialCMS.Website.Filters;

namespace MaterialCMS.Tasks
{
    public class SitemapController : MaterialCMSUIController
    {
        public const string WriteSitemapUrl = "update-sitemap";
        public const string SitemapUrl = "sitemap.xml";
        private readonly ISitemapService _sitemapService;
        private readonly IGetSitemapPath _getSitemapPath;
        private readonly Site _site;


        public SitemapController(ISitemapService sitemapService, IGetSitemapPath getSitemapPath, Site site)
        {
            _sitemapService = sitemapService;
            _getSitemapPath = getSitemapPath;
            _site = site;
        }

        [TaskExecutionKeyPasswordAuth]
        public ContentResult Update()
        {
            _sitemapService.WriteSitemap();
            return new ContentResult { Content = "Executed", ContentType = "text/plain" };
        }

        public ActionResult Show()
        {
            var fileName = _getSitemapPath.GetPath(_site);
            if (_getSitemapPath.FileExists(fileName))
                return File(fileName, "text/plain");
            return new EmptyResult();
        }
    }
}