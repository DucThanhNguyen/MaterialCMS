using System.Web.Mvc;
using System.Web.UI;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class BatchController : MaterialCMSAdminController
    {
        private readonly IBatchAdminService _batchAdminService;

        public BatchController(IBatchAdminService batchAdminService)
        {
            _batchAdminService = batchAdminService;
        }

        public ViewResult Index(BatchSearchModel searchModel)
        {
            ViewData["results"] = _batchAdminService.Search(searchModel);
            return View(searchModel);
        }

        public ViewResult Show(Batch batch)
        {
            return View(batch);
        }

        public ActionResult ShowPartial(Batch batch)
        {
            return PartialView("Show", batch);
        }
    }
}