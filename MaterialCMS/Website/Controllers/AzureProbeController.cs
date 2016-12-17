using System.Web.Mvc;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Helpers;
using MaterialCMS.Settings;
using NHibernate;

namespace MaterialCMS.Website.Controllers
{
    public class AzureProbeController : MaterialCMSUIController
    {
        private readonly AzureProbeSettings _azureProbeSettings;
        private readonly IStatelessSession _session;

        public AzureProbeController(AzureProbeSettings azureProbeSettings, IStatelessSession session)
        {
            _azureProbeSettings = azureProbeSettings;
            _session = session;
        }

        public ActionResult KeepAlive()
        {
            var item = HttpContext.Request[_azureProbeSettings.Key];
            if (string.IsNullOrWhiteSpace(item) || item != _azureProbeSettings.Password)
                return new HttpStatusCodeResult(403);

            return new HttpStatusCodeResult(!_session.QueryOver<Site>().Any() ? 500 : 200);
        }
    }
}