using System.Threading.Tasks;
using System.Web.Mvc;
using MaterialCMS.Settings;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class ThirdPartyAuthController : MaterialCMSAdminController
    {
        private readonly IThirdPartyAuthSettingsAdminService _thirdPartyAuthSettingsAdminService;

        public ThirdPartyAuthController(IThirdPartyAuthSettingsAdminService thirdPartyAuthSettingsAdminService)
        {
            _thirdPartyAuthSettingsAdminService = thirdPartyAuthSettingsAdminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_thirdPartyAuthSettingsAdminService.GetSettings());
        }

        [HttpPost]
        public RedirectToRouteResult Index([IoCModelBinder(typeof(ThirdPartyAuthSettingsModelBinder))] ThirdPartyAuthSettings thirdPartyAuthSettings)
        {
            _thirdPartyAuthSettingsAdminService.SaveSettings(thirdPartyAuthSettings);
            return RedirectToAction("Index");
        }
    }
}