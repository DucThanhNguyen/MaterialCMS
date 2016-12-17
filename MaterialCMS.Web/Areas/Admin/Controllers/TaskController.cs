using System.Web.Mvc;
using MaterialCMS.Settings;
using MaterialCMS.Tasks;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class TaskController : MaterialCMSAdminController
    {
        private readonly ITaskAdminService _taskAdminService;

        public TaskController(ITaskAdminService taskAdminService)
        {
            _taskAdminService = taskAdminService;
        }

        public ViewResult Index(QueuedTaskSearchQuery searchQuery)
        {
            ViewData["scheduled-tasks"] = _taskAdminService.GetAllScheduledTasks();
            ViewData["tasks"] = _taskAdminService.GetQueuedTasks(searchQuery);
            return View(searchQuery);
        }

        [HttpGet]
        public PartialViewResult Edit(string type)
        {
            var taskInfo = _taskAdminService.GetTaskUpdateData(type);
            return PartialView(taskInfo);
        }

        [HttpPost]
        public RedirectToRouteResult Edit(TaskUpdateData taskInfo)
        {
            _taskAdminService.Update(taskInfo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult Reset(string type)
        {
            var taskInfo = _taskAdminService.GetTaskUpdateData(type);
            return PartialView(taskInfo);
        }

        [HttpPost]
        public RedirectToRouteResult Reset(TaskUpdateData taskInfo)
        {
            _taskAdminService.Reset(taskInfo);

            return RedirectToAction("Index");
        }
    }
}