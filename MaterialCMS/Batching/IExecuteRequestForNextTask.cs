using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching
{
    public interface IExecuteRequestForNextTask
    {
        void Execute(BatchRun run);
    }
}