using System.Threading.Tasks;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface IBatchJobExecutionService
    {
        Task<BatchJobExecutionResult> Execute(BatchJob batchJob);
    }
}