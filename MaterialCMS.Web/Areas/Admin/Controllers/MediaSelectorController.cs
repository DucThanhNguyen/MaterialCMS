using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class MediaSelectorController : MaterialCMSAdminController
    {
        private readonly IMediaSelectorService _mediaSelectorService;

        public MediaSelectorController(IMediaSelectorService mediaSelectorService)
        {
            _mediaSelectorService = mediaSelectorService;
        }

        public ActionResult Show(MediaSelectorSearchQuery searchQuery)
        {
            ViewData["categories"] = _mediaSelectorService.GetCategories();
            ViewData["results"] = _mediaSelectorService.Search(searchQuery);
            return PartialView(searchQuery);
        }

        [HttpGet]
        public JsonResult Alt(string url)
        {
            return Json(new { alt = _mediaSelectorService.GetAlt(url) });
        }

        [HttpPost]
        public JsonResult UpdateAlt(UpdateMediaParams updateMediaParams)
        {
            return Json(_mediaSelectorService.UpdateAlt(updateMediaParams));
        }

        [HttpGet]
        public JsonResult Description(string url)
        {
            return Json(new { description = _mediaSelectorService.GetDescription(url) });
        }

        [HttpPost]
        public JsonResult UpdateDescription(UpdateMediaParams updateMediaParams)
        {
            return Json(_mediaSelectorService.UpdateDescription(updateMediaParams));
        }

        public JsonResult GetFileInfo(string value)
        {
            return Json(_mediaSelectorService.GetFileInfo(value), JsonRequestBehavior.AllowGet);
        }
    }
}