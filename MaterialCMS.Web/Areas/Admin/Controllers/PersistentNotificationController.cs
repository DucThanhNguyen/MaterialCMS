using System;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class PersistentNotificationController : MaterialCMSAdminController
    {
        private readonly IPersistentNotificationUIService _service;

        public PersistentNotificationController(IPersistentNotificationUIService service)
        {
            _service = service;
        }

        public PartialViewResult Show()
        {
            return PartialView();
        }

        public JsonResult Get()
        {
            return Json(_service.GetNotifications(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCount()
        {
            return Json(_service.GetNotificationCount(), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Navbar()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult MarkAllAsRead()
        {
            _service.MarkAllAsRead();
            return Json(true);
        }
    }
}