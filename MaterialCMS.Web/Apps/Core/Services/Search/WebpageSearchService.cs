using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Querying;
using MaterialCMS.Paging;
using MaterialCMS.Services;
using MaterialCMS.Web.Apps.Core.Indexing;
using MaterialCMS.Web.Apps.Core.Models.Search;

namespace MaterialCMS.Web.Apps.Core.Services.Search
{
    public class WebpageSearchService : IWebpageSearchService
    {
        private readonly ISearcher<Webpage, WebpageSearchIndexDefinition> _documentSearcher;
        private readonly IGetBreadcrumbs _getBreadcrumbs;

        public WebpageSearchService(ISearcher<Webpage, WebpageSearchIndexDefinition> documentSearcher, IGetBreadcrumbs getBreadcrumbs)
        {
            _documentSearcher = documentSearcher;
            _getBreadcrumbs = getBreadcrumbs;
        }

        public IPagedList<Webpage> Search(WebpageSearchQuery model)
        {
            return _documentSearcher.Search(model.GetQuery(), model.Page);
        }

        public IEnumerable<Document> GetBreadCrumb(int? parentId)
        {
            return _getBreadcrumbs.Get(parentId).Reverse();
        }
    }
}