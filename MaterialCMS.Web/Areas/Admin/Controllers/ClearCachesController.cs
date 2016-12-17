using System.Web.Mvc;
using MaterialCMS.Website;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class ClearCachesController : MaterialCMSAdminController
    {
        private readonly IClearCachesService _clearCachesService;

        public ClearCachesController(IClearCachesService clearCachesService)
        {
            _clearCachesService = clearCachesService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            ViewData["cleared"] = TempData["cleared"];
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public RedirectToRouteResult Index_POST()
        {
            _clearCachesService.ClearCache();
            TempData["cleared"] = true;
            return RedirectToAction("Index");
        }
    }
}