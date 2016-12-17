using System;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class PageTemplateController : MaterialCMSAdminController
    {
        private readonly IPageTemplateAdminService _service;

        public PageTemplateController(IPageTemplateAdminService service)
        {
            _service = service;
        }

        public ViewResult Index(PageTemplateSearchQuery query)
        {
            ViewData["results"] = _service.Search(query);
            return View(query);
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            ViewData["page-type-options"] = _service.GetPageTypeOptions();
            ViewData["layout-options"] = _service.GetLayoutOptions();
            ViewData["url-generator-options"] = _service.GetUrlGeneratorOptions(null);
            return PartialView();
        }

        [HttpPost]
        public RedirectToRouteResult Add(PageTemplate template)
        {
            _service.Add(template);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult Edit(PageTemplate template)
        {
            ViewData["layout-options"] = _service.GetLayoutOptions();
            ViewData["url-generator-options"] = _service.GetUrlGeneratorOptions(template.GetPageType());
            return PartialView(template);
        }

        [HttpPost]
        [ActionName("Edit")]
        public RedirectToRouteResult Edit_POST(PageTemplate template)
        {
            _service.Update(template);
            return RedirectToAction("Index");
        }

        public JsonResult GetUrlGeneratorOptions(
            [IoCModelBinder(typeof (GetUrlGeneratorOptionsTypeModelBinder))] Type type)
        {
            return Json(_service.GetUrlGeneratorOptions(type), JsonRequestBehavior.AllowGet);
        }
    }
}