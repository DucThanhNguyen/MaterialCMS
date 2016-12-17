using System;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class PageDefaultsController : MaterialCMSAdminController
    {
        private readonly IPageDefaultsAdminService _service;

        public PageDefaultsController(IPageDefaultsAdminService service)
        {
            _service = service;
        }

        public ViewResult Index()
        {
            return View(_service.GetAll());
        }

        [HttpGet]
        public PartialViewResult Set([IoCModelBinder(typeof(GetUrlGeneratorOptionsTypeModelBinder))] Type type)
        {
            ViewData["url-generator-options"] = _service.GetUrlGeneratorOptions(type);
            ViewData["layout-options"] = _service.GetLayoutOptions();
            return PartialView(_service.GetInfo(type));
        }

        [HttpPost]
        public RedirectToRouteResult Set(DefaultsInfo info)
        {
            _service.SetDefaults(info);
            return RedirectToAction("Index");
        }
    }
}