using System.Xml;
using System.Xml.Linq;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services.Sitemaps
{
    public interface ISitemapElementAppender
    {
        void AddSiteMapData(SitemapData webpage, XElement urlset, XDocument xmlDocument);
    }
}