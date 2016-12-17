using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class DashboardController : MaterialCMSAdminController
    {
        [DashboardAreaAction(DashboardArea = DashboardArea.Top, Order = -1)]
        public PartialViewResult Greeting()
        {
            return PartialView();
        }
    }
}