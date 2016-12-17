using System.Web.Mvc;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class BatchRunResultController : MaterialCMSAdminController
    {
        public PartialViewResult Show(BatchRunResult result)
        {
            return PartialView(result);
        }
    }
}