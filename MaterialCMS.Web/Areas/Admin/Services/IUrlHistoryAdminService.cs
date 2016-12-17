using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IUrlHistoryAdminService
    {
        void Delete(UrlHistory urlHistory);
        void Add(UrlHistory urlHistory);
        UrlHistory GetByUrlSegment(string url);
        UrlHistory GetByUrlSegmentWithSite(string url, Site site, Webpage page);
        UrlHistory GetUrlHistoryToAdd(int webpageId);
    }
}