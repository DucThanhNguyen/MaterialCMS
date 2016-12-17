using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models.Search;

namespace MaterialCMS.Web.Areas.Admin.Services.Search
{
    public interface IAdminSearchService
    {
        IPagedList<AdminSearchResult> Search(AdminSearchQuery model);
    }
}