using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models.Search;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IAdminWebpageSearchService
    {
        IPagedList<Webpage> Search(AdminWebpageSearchQuery model);
        IEnumerable<QuickSearchResult> QuickSearch(AdminWebpageSearchQuery model);
        IEnumerable<Document> GetBreadCrumb(int? parentId);
        List<SelectListItem> GetDocumentTypes(string type);
        List<SelectListItem> GetParentsList();
    }
}