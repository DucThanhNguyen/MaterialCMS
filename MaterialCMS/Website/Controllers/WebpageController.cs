using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website.Controllers
{
    public class WebpageController : MaterialCMSUIController
    {
        public ViewResult Show(Webpage page)
        {
            return View(page);
        }
    }
}