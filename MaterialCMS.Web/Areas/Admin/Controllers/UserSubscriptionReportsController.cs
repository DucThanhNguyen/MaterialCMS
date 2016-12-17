using System.Web.Mvc;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Entities.People;
using MaterialCMS.Models;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services.UserSubscriptionReports;
using MaterialCMS.Website;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;
using System.Collections.Generic;
using MaterialCMS.Web.Areas.Admin.Models.UserSubscriptionReports;
using MaterialCMS.Web.Areas.Admin.ACL.UserSubscriptionReports;
using Newtonsoft.Json;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class UserSubscriptionReportsController : MaterialCMSAdminController
    {
        private readonly IUserSubscriptionReportsService _userSubscriptionReportsService;

        public UserSubscriptionReportsController(IUserSubscriptionReportsService userSubscriptionReportsService)
        {
            _userSubscriptionReportsService = userSubscriptionReportsService;
        }

        [MaterialCMSACLRule(typeof(UserSubscriptionReportsACL), UserSubscriptionReportsACL.View)]
        public ViewResult Index(UserSubscriptionReportsSearchQuery searchQuery)
        {
            return View(searchQuery);
        }

        [MaterialCMSACLRule(typeof (UserSubscriptionReportsACL), UserSubscriptionReportsACL.View)]
        public JsonResult GraphData(UserSubscriptionReportsSearchQuery searchQuery)
        {
            var data = _userSubscriptionReportsService.GetAllSubscriptions(searchQuery);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}