using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class SiteCloneOptionsController : MaterialCMSAdminController
    {
        private readonly ISiteCloneOptionsAdminService _siteCloneOptionsAdminService;

        public SiteCloneOptionsController(ISiteCloneOptionsAdminService siteCloneOptionsAdminService)
        {
            _siteCloneOptionsAdminService = siteCloneOptionsAdminService;
        }

        public PartialViewResult Get()
        {
            ViewData["other-sites"] = _siteCloneOptionsAdminService.GetOtherSiteOptions();

            return PartialView(_siteCloneOptionsAdminService.GetClonePartOptions());
        }
    }
}