using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Settings;

namespace MaterialCMS.Services.Sitemaps
{
    public class ExcludeFromSitemapBecauseIsErrorPage : IReasonToExcludePageFromSitemap
    {
        private readonly SiteSettings _siteSettings;

        public ExcludeFromSitemapBecauseIsErrorPage(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public bool ShouldExclude(Webpage webpage)
        {
            if (webpage == null)
                return true;
            return _siteSettings.Error403PageId == webpage.Id
                   || _siteSettings.Error404PageId == webpage.Id
                   || _siteSettings.Error500PageId == webpage.Id;
        }
    }
}