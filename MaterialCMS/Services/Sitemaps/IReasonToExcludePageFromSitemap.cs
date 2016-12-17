using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services.Sitemaps
{
    public interface IReasonToExcludePageFromSitemap
    {
        bool ShouldExclude(Webpage webpage);
    }
}