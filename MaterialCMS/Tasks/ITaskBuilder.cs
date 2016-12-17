using System;
using System.Collections.Generic;

namespace MaterialCMS.Tasks
{
    public interface ITaskBuilder
    {
        IList<AdHocTask> GetTasksToExecute(IList<QueuedTask> pendingQueuedTasks);
    }
}