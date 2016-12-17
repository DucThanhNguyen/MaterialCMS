using MaterialCMS.Batching;
using MaterialCMS.Batching.Events;

namespace MaterialCMS.Web.Areas.Admin.Events
{
    public class StartBatchExecutionOnServer : IOnBatchRunStart
    {
        private readonly IExecuteRequestForNextTask _executeRequestForNextTask;

        public StartBatchExecutionOnServer(IExecuteRequestForNextTask executeRequestForNextTask)
        {
            _executeRequestForNextTask = executeRequestForNextTask;
        }

        public void Execute(BatchRunStartArgs args)
        {
            _executeRequestForNextTask.Execute(args.BatchRun);
        }
    }
}