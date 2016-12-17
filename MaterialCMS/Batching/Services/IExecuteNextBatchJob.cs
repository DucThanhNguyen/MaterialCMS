using System.Threading.Tasks;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface IExecuteNextBatchJob
    {
        Task<bool> Execute(BatchRun batchRun);
    }
}