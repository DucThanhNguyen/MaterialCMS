using System.Collections.Generic;
using MaterialCMS.Paging;
using MaterialCMS.Tasks;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ITaskAdminService
    {
        List<TaskInfo> GetAllScheduledTasks();
        TaskUpdateData GetTaskUpdateData(string type);
        IPagedList<QueuedTask> GetQueuedTasks(QueuedTaskSearchQuery searchQuery);
        void Update(TaskUpdateData info);
        void Reset(TaskUpdateData info);
    }
}