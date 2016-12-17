using System.Web.Mvc;
using MaterialCMS.Settings;

namespace MaterialCMS.Website.Controllers
{
    public class CKEditorController : MaterialCMSUIController
    {
        private readonly SiteSettings _siteSettings;

        public CKEditorController(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public ContentResult Config()
        {
            return Content(_siteSettings.CKEditorConfig, "application/javascript");
        }
    }
}