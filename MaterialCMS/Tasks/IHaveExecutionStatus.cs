using System;

namespace MaterialCMS.Tasks
{
    public interface IHaveExecutionStatus
    {
        void OnStarting(AdHocTask executableTask);
        void OnSuccess(AdHocTask executableTask);
        void OnFailure(AdHocTask executableTask, Exception exception);
    }
}