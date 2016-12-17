using System;

namespace MaterialCMS.Tasks
{
    public interface IScheduledTaskRunner
    {
        void TriggerScheduledTasks();
        void ExecuteTask(string type);
    }
}