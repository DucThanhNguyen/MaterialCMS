using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class SiteListController : MaterialCMSAdminController
    {
        private readonly IAdminSiteListService _siteListService;

        public SiteListController(IAdminSiteListService siteListService)
        {
            _siteListService = siteListService;
        }

        public ActionResult Get()
        {
            return PartialView(_siteListService.GetSites());
        }
    }
}