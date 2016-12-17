using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class PageStatsController : MaterialCMSAdminController
    {
        private readonly IAdminPageStatsService _pageStatsService;

        public PageStatsController(IAdminPageStatsService pageStatsService)
        {
            _pageStatsService = pageStatsService;
        }

        [DashboardAreaAction(DashboardArea = DashboardArea.LeftColumn, Order = 100)]
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public PartialViewResult Summary()
        {
            return PartialView(_pageStatsService.GetSummary());
        }
    }
}