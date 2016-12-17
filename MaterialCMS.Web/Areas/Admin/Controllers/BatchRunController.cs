using System.Web.Mvc;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Web.Areas.Admin.Services.Batching;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class BatchRunController : MaterialCMSAdminController
    {
        private readonly IBatchRunUIService _batchRunUIService;

        public BatchRunController(IBatchRunUIService batchRunUIService)
        {
            _batchRunUIService = batchRunUIService;
        }

        public ViewResult Show(BatchRun batchRun)
        {
            return View(batchRun);
        }

        public PartialViewResult ShowPartial(BatchRun batchRun)
        {
            return PartialView("Show", batchRun);
        }

        [HttpPost]
        public JsonResult Start(BatchRun run)
        {
            return Json(_batchRunUIService.Start(run));
        }

        [HttpPost]
        public JsonResult Pause(BatchRun run)
        {
            return Json(_batchRunUIService.Pause(run));
        }

        public ActionResult Status(BatchRun batchRun)
        {
            ViewData["completion-status"] = _batchRunUIService.GetCompletionStatus(batchRun);
            return PartialView(batchRun);
        }

        public ActionResult Row(BatchRun batchRun)
        {
            ViewData["completion-status"] = _batchRunUIService.GetCompletionStatus(batchRun);
            return PartialView(batchRun);
        }
    }
}