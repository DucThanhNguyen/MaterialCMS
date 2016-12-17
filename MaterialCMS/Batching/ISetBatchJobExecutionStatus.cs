using MaterialCMS.Batching.Entities;
using MaterialCMS.Entities;

namespace MaterialCMS.Batching
{
    public interface ISetBatchJobExecutionStatus
    {
        void Starting<T>(T entity) where T : SystemEntity, IHaveJobExecutionStatus;
        void Complete<T>(T entity, BatchJobExecutionResult result) where T : SystemEntity, IHaveJobExecutionStatus;
    }
}