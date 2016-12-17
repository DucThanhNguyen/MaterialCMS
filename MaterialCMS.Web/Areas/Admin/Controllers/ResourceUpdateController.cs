using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class ResourceUpdateController : MaterialCMSAdminController
    {
        private readonly IStringResourceUpdateService _stringResourceUpdateService;

        public ResourceUpdateController(IStringResourceUpdateService stringResourceUpdateService)
        {
            _stringResourceUpdateService = stringResourceUpdateService;
        }

        public FileResult Export(StringResourceSearchQuery searchQuery)
        {
            return _stringResourceUpdateService.Export(searchQuery);
        }

        [HttpPost]
        public RedirectToRouteResult Import()
        {
            var summary = _stringResourceUpdateService.Import(Request.Files[0]);
            TempData.SuccessMessages()
                .Add(string.Format("{0} resourced procesed - {1} added, {2} updated",
                    summary.Processed, summary.Added, summary.Updated));
            return RedirectToAction("Index", "Resource");
        }
    }
}