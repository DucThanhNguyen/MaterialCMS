using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface ISetRunStatus
    {
        void Complete(BatchRun batchRun);
        void Paused(BatchRun batchRun);
    }
}