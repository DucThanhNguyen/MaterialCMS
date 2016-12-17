using System.Collections.Generic;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Models.Search;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IUniversalSearchIndexSearcher
    {
        List<UniversalSearchItemQuickSearch> QuickSearch(QuickSearchParams searchParams);
        IPagedList<AdminSearchResult> Search(AdminSearchQuery searchQuery);
    }
}