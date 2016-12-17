using System.Collections.Generic;
using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Tasks
{
    public interface ITaskQueuer
    {
        IList<QueuedTask> GetPendingQueuedTasks();
        IList<QueuedTask> GetPendingLuceneTasks();
        IList<Site> GetPendingQueuedTaskSites();
    }
}