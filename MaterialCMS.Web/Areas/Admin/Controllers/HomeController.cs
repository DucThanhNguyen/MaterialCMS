using System.Web.Mvc;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class HomeController : MaterialCMSAdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}