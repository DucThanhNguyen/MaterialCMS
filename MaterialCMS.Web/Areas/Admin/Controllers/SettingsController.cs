using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Helpers;
using MaterialCMS.Settings;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Website;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class SettingsController : MaterialCMSAdminController
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ISession _session;

        public SettingsController(IConfigurationProvider configurationProvider, ISession session)
        {
            _configurationProvider = configurationProvider;
            _session = session;
        }

        [HttpGet]
        [MaterialCMSACLRule(typeof(SiteSettingsACL), SiteSettingsACL.View)]
        public ViewResult Index()
        {
            var settings = _configurationProvider.GetAllSiteSettings().FindAll(arg => arg.RenderInSettings);
            settings.ForEach(@base => @base.SetViewData(_session, ViewData));
            return View(settings);
        }

        [HttpPost]
        [ActionName("Index")]
        [MaterialCMSACLRule(typeof(SiteSettingsACL), SiteSettingsACL.Save)]
        public RedirectToRouteResult Index_Post([IoCModelBinder(typeof(SiteSettingsModelBinder))]List<SiteSettingsBase> settings)
        {
            settings.ForEach(s => _configurationProvider.SaveSettings(s));
            TempData["settings-saved"] = true;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult FileSystem()
        {
            return View(_configurationProvider.GetSiteSettings<FileSystemSettings>());
        }

        [HttpPost]
        public RedirectToRouteResult FileSystem([IoCModelBinder(typeof(FileSystemSettingsModelBinder))]FileSystemSettings settings)
        {
            _configurationProvider.SaveSettings(settings);
            TempData.SuccessMessages().Add("Settings saved.".AsResource(HttpContext));
            return RedirectToAction("FileSystem");
        }

     
    }
}