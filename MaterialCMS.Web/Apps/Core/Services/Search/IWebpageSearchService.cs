using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Paging;
using MaterialCMS.Web.Apps.Core.Models.Search;

namespace MaterialCMS.Web.Apps.Core.Services.Search
{
    public interface IWebpageSearchService
    {
        IPagedList<Webpage> Search(WebpageSearchQuery model);
        IEnumerable<Document> GetBreadCrumb(int? parentId);
    }
}
