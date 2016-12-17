using System.Web.Mvc;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class BatchJobController : MaterialCMSAdminController
    {
        public ActionResult Row(BatchJob batchJob)
        {
            return PartialView(batchJob);
        } 
    }
}