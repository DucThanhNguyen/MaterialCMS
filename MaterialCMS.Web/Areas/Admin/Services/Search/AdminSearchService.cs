using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models.Search;

namespace MaterialCMS.Web.Areas.Admin.Services.Search
{
    public class AdminSearchService : IAdminSearchService
    {
        private readonly IUniversalSearchIndexSearcher _universalSearchIndexSearcher;

        public AdminSearchService(IUniversalSearchIndexSearcher universalSearchIndexSearcher)
        {
            _universalSearchIndexSearcher = universalSearchIndexSearcher;
        }

        public IPagedList<AdminSearchResult> Search(AdminSearchQuery model)
        {
            return _universalSearchIndexSearcher.Search(model);
        }
    }
}