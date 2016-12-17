using System.Collections.Generic;

namespace MaterialCMS.Tasks
{
    public interface ITaskExecutor
    {
        BatchExecutionResult Execute(IList<AdHocTask> tasksToExecute);
        BatchExecutionResult Execute(AdHocTask task);
    }
}