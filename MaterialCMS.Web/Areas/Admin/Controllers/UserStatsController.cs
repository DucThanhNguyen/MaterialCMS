using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class UserStatsController : MaterialCMSAdminController
    {
        private readonly IAdminUserStatsService _userStatsService;

        public UserStatsController(IAdminUserStatsService userStatsService)
        {
            _userStatsService = userStatsService;
        }

        [DashboardAreaAction(DashboardArea = DashboardArea.RightColumn, Order = 101)]
        public PartialViewResult Summary()
        {
            return PartialView(_userStatsService.GetSummary());
        }
    }
}