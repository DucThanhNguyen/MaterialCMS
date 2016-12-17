using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IWebpageParentAdminService
    {
        IEnumerable<SelectListItem> GetValidParents(Webpage webpage);
        void Set(Webpage webpage, int? parentId);
    }
}