using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Controllers;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IWebpageAdminSearchService
    {
        IPagedList<Webpage> Search(WebpageSearchQuery searchQuery);
    }
}