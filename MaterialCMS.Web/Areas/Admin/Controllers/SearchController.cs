using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models.Search;
using MaterialCMS.Web.Areas.Admin.Services.Search;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class SearchController : MaterialCMSAdminController
    {
        private readonly IAdminSearchService _adminSearchService;

        public SearchController(IAdminSearchService adminSearchService)
        {
            _adminSearchService = adminSearchService;
        }

        [HttpGet]
        public ActionResult Index(AdminSearchQuery model)
        {
            ViewData["results"] = _adminSearchService.Search(model);

            return View(model);
        }
    }
}