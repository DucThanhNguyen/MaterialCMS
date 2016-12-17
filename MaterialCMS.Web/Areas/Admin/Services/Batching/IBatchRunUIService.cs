using System.Collections.Generic;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Web.Areas.Admin.Services.Batching
{
    public interface IBatchRunUIService
    {
        IList<BatchRunResult> GetResults(BatchRun batchRun);
        int? Start(BatchRun run);
        bool Pause(BatchRun run);
        BatchCompletionStatus GetCompletionStatus(BatchRun batchRun);
    }
}