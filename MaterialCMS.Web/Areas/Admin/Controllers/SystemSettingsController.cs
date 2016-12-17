using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Settings;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Website;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class SystemSettingsController : MaterialCMSAdminController
    {
        private readonly ISystemConfigurationProvider _configurationProvider;

        public SystemSettingsController(ISystemConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        [MaterialCMSACLRule(typeof(SystemSettingsACL), SystemSettingsACL.View)]
        public ViewResult Index()
        {
            var settings = _configurationProvider.GetAllSystemSettings().FindAll(arg => arg.RenderInSettings);
            return View(settings);
        }

        [HttpPost]
        [ActionName("Index")]
        [MaterialCMSACLRule(typeof(SystemSettingsACL), SystemSettingsACL.Save)]
        public RedirectToRouteResult Index_Post([IoCModelBinder(typeof(SystemSettingsModelBinder))]List<SystemSettingsBase> settings)
        {
            settings.ForEach(s => _configurationProvider.SaveSettings(s));
            TempData["settings-saved"] = true;
            return RedirectToAction("Index");
        }
        
    }
}