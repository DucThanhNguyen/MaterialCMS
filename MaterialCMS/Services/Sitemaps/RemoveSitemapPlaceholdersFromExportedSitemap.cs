using System.Xml.Linq;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services.Sitemaps
{
    public class RemoveSitemapPlaceholdersFromExportedSitemap : SitemapGenerationInfo<SitemapPlaceholder>
    {
        public override bool ShouldAppend(SitemapPlaceholder webpage)
        {
            return false;
        }

        public override void Append(SitemapPlaceholder webpage, XElement urlset, XDocument xmlDocument)
        {
        }
    }
}