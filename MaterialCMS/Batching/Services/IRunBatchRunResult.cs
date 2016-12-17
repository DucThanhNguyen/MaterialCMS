using System.Diagnostics;
using System.Threading.Tasks;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface IRunBatchRunResult
    {
        Task<BatchJobExecutionResult> Run(BatchRunResult runResult, Stopwatch stopWatch = null);
    }
}