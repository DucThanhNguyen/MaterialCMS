using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Documents.Web.FormProperties;
using MaterialCMS.Helpers;
using MaterialCMS.Models;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class FormController : MaterialCMSAdminController
    {
        private readonly IFormAdminService _formAdminService;

        public FormController(IFormAdminService formAdminService)
        {
            _formAdminService = formAdminService;
        }

        public PartialViewResult Postings(Webpage webpage, int page = 1, string search = null)
        {
            var data = _formAdminService.GetFormPostings(webpage, page, search);

            return PartialView(data);
        }

        public ActionResult ViewPosting(FormPosting formPosting)
        {
            return PartialView(formPosting);
        }

        [HttpGet]
        public ViewResult AddProperty(Webpage webpage)
        {
            ViewData["property-types"] = new List<Type>
                                             {
                                                 typeof (TextBox),
                                                 typeof (DropDownList),
                                                 typeof (TextArea),
                                                 typeof (CheckboxList),
                                                 typeof (RadioButtonList),
                                                 typeof (FileUpload)
                                             }
                .BuildSelectItemList(type => type.Name.BreakUpString(),
                                     type => type.Name,
                                     emptyItemText: null);
            return View(new TextBox { Webpage = webpage });
        }

        [HttpPost]
        public JsonResult AddProperty([IoCModelBinder(typeof(AddFormPropertyModelBinder))] FormProperty formProperty)
        {
            _formAdminService.AddFormProperty(formProperty);
            return Json(new FormActionResult { success = true });
        }

        [HttpGet]
        public ViewResult EditProperty(FormProperty property)
        {
            return View(property);
        }

        [HttpPost]
        [ActionName("EditProperty")]
        public JsonResult EditProperty_POST(FormProperty property)
        {
            _formAdminService.SaveFormProperty(property);
            return Json(new FormActionResult { success = true });
        }

        [HttpGet]
        public ViewResult DeleteProperty(FormProperty property)
        {
            return View(property);
        }
        [HttpPost]
        [ActionName("DeleteProperty")]
        public JsonResult DeleteProperty_POST(FormProperty property)
        {
            _formAdminService.DeleteFormProperty(property);
            return Json(new FormActionResult { success = true });
        }

        [HttpGet]
        public ActionResult AddOption(FormPropertyWithOptions formProperty)
        {
            return View(new FormListOption { FormProperty = formProperty });
        }

        [HttpPost]
        public ActionResult AddOption(FormListOption formListOption)
        {
            _formAdminService.SaveFormListOption(formListOption);
            return Json(new FormActionResult { success = true });
        }

        [HttpGet]
        public ActionResult EditOption(FormListOption formListOption)
        {
            return View(formListOption);
        }

        [HttpPost]
        [ActionName("EditOption")]
        public ActionResult EditOption_POST(FormListOption formListOption)
        {
            _formAdminService.UpdateFormListOption(formListOption);
            return Json(new FormActionResult { success = true });
        }

        [HttpGet]
        public ActionResult DeleteOption(FormListOption formListOption)
        {
            return View(formListOption);
        }

        [HttpPost]
        [ActionName("DeleteOption")]
        public ActionResult DeleteOption_POST(FormListOption formListOption)
        {
            _formAdminService.DeleteFormListOption(formListOption);
            return Json(new FormActionResult { success = true });
        }


        [HttpGet]
        public ActionResult Sort(Webpage webpage)
        {
            var sortItems = webpage.FormProperties.OrderBy(x=>x.DisplayOrder)
                                .Select(
                                    arg => new SortItem { Order = arg.DisplayOrder, Id = arg.Id, Name = arg.Name })
                                .ToList();

            return View(sortItems);
        }

        [HttpPost]
        public void Sort(List<SortItem> items)
        {
            _formAdminService.SetOrders(items);
        }

        [HttpGet]
        public PartialViewResult ClearFormData(Webpage webpage)
        {
            return PartialView(webpage);
        }

        [HttpPost]
        [ActionName("ClearFormData")]
        public RedirectToRouteResult ClearFormData_POST(Webpage webpage)
        {
            _formAdminService.ClearFormData(webpage);
            return RedirectToAction("Edit","Webpage", new { id = webpage.Id });
        }

        [HttpGet]
        public ActionResult ExportFormData(Webpage webpage)
        {
            try
            {
                var file = _formAdminService.ExportFormData(webpage);
                return File(file, "text/csv", "MaterialCMS-FormData-[" + webpage.UrlSegment + "]-" + DateTime.UtcNow + ".csv");
            }
            catch (Exception ex)
            {
                CurrentRequestData.ErrorSignal.Raise(ex);
                return RedirectToAction("Edit", "Webpage", new { id = webpage.Id });
            }
        }

        [HttpGet]
        public ViewResult DeleteEntry(FormPosting posting)
        {
            return View(posting);
        }
        [HttpPost]
        [ActionName("DeleteEntry")]
        public ActionResult DeleteEntry_POST(FormPosting posting)
        {
            _formAdminService.DeletePosting(posting);
            return RedirectToAction("Edit", "Webpage", new { id = posting.Webpage.Id });
        }
    }

    public class FormActionResult
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}