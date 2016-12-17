using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class NavLinksController : MaterialCMSAdminController
    {
        private readonly IAdminNavLinksService _navLinksService;

        public NavLinksController(IAdminNavLinksService navLinksService)
        {
            _navLinksService = navLinksService;
        }

        public PartialViewResult Get()
        {
            return PartialView(_navLinksService.GetNavLinks());
        }
    }
}