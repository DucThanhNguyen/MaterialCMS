using System.Web.Mvc;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Entities.Resources;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class ResourceController : MaterialCMSAdminController
    {
        private readonly IStringResourceAdminService _stringResourceAdminService;

        public ResourceController(IStringResourceAdminService stringResourceAdminService)
        {
            _stringResourceAdminService = stringResourceAdminService;
        }

        public ViewResult Index(StringResourceSearchQuery searchQuery)
        {
            ViewData["results"] = _stringResourceAdminService.Search(searchQuery);
            ViewData["language-options"] = _stringResourceAdminService.SearchLanguageOptions();
            ViewData["site-options"] = _stringResourceAdminService.SearchSiteOptions();
            return View(searchQuery);
        }

        [HttpGet]
        public ViewResult ChooseSite(ChooseSiteParams chooseSiteParams)
        {
            ViewData["site-options"] = _stringResourceAdminService.ChooseSiteOptions(chooseSiteParams);
            return View(chooseSiteParams);
        }

        [HttpGet]
        public ViewResult Add(string key, [IoCModelBinder(typeof(NullableEntityModelBinder))] Site site, bool language = false)
        {
            if (language)
                ViewData["language-options"] = _stringResourceAdminService.GetLanguageOptions(key, site);

            return View(_stringResourceAdminService.GetNewResource(key, site));
        }

        [HttpPost]
        [ActionName("Add")]
        public RedirectToRouteResult Add_POST(StringResource resource)
        {
            _stringResourceAdminService.Add(resource);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(StringResource resource)
        {
            return View(resource);
        }

        [HttpPost]
        [ActionName("Edit")]
        public RedirectToRouteResult Edit_POST(StringResource resource)
        {
            _stringResourceAdminService.Update(resource);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Delete(StringResource resource)
        {
            return View(resource);
        }

        [HttpPost]
        [ActionName("Delete")]
        public RedirectToRouteResult Delete_POST(StringResource resource)
        {
            _stringResourceAdminService.Delete(resource);
            return RedirectToAction("Index");
        }
    }
}