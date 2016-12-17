using System.Web;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IStringResourceUpdateService
    {
        FileResult Export(StringResourceSearchQuery searchQuery);
        ResourceImportSummary Import(HttpPostedFileBase file);
    }
}