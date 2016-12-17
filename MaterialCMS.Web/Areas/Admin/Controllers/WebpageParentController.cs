using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class WebpageParentController : MaterialCMSAdminController
    {
        private readonly IWebpageParentAdminService _webpageParentAdminService;

        public WebpageParentController(IWebpageParentAdminService webpageParentAdminService)
        {
            _webpageParentAdminService = webpageParentAdminService;
        }

        [HttpGet]
        public PartialViewResult Set(Webpage webpage)
        {
            ViewData["valid-parents"] = _webpageParentAdminService.GetValidParents(webpage);
            return PartialView(webpage);
        }

        [HttpPost]
        public RedirectToRouteResult Set(Webpage webpage, int? parentVal)
        {
            _webpageParentAdminService.Set(webpage, parentVal);

            return RedirectToAction("Edit", "Webpage", new { id = webpage.Id });
        }
    }
}