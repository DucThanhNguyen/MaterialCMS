using System.Web.Mvc;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class TransientNotificationController : MaterialCMSAdminController
    {
        public PartialViewResult Show()
        {
            return PartialView();
        }
    }
}