using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface IControlBatchRun
    {
        bool Start(BatchRun batchRun);
        bool Pause(BatchRun batchRun);
    }
}