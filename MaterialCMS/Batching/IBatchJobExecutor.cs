using System.Threading.Tasks;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching
{
    public interface IBatchJobExecutor
    {
        Task<BatchJobExecutionResult> Execute(BatchJob batchJob);
        bool UseAsync { get; }
    }
}