using System.Web.Mvc;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class AboutController : MaterialCMSAdminController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}