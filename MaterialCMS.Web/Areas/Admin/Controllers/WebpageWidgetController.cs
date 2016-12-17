using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class WebpageWidgetController : MaterialCMSAdminController
    {
        private readonly IWebpageWidgetAdminService _webpageWidgetAdminService;

        public WebpageWidgetController(IWebpageWidgetAdminService webpageWidgetAdminService)
        {
            _webpageWidgetAdminService = webpageWidgetAdminService;
        }

        [HttpPost]
        public ActionResult Hide(Webpage document, int widgetId, int layoutAreaId)
        {
            _webpageWidgetAdminService.Hide(document, widgetId);
            return RedirectToAction("Edit", "Webpage", new { id = document.Id, layoutAreaId });
        }

        [HttpPost]
        public ActionResult Show(Webpage document, int widgetId, int layoutAreaId)
        {
            _webpageWidgetAdminService.Show(document, widgetId);
            return RedirectToAction("Edit", "Webpage", new { id = document.Id, layoutAreaId });
        }
    }
}