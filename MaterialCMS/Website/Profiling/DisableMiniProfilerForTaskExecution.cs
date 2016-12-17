using System;
using System.Web;
using MaterialCMS.Tasks;

namespace MaterialCMS.Website.Profiling
{
    public class DisableMiniProfilerForTaskExecution : IReasonToDisableMiniProfiler
    {
        public bool ShouldDisableFor(HttpRequest request)
        {
            return
                request.RequestContext.HttpContext.Request.Url.AbsolutePath.TrimStart('/')
                    .StartsWith(TaskExecutionController.ExecutePendingTasksURL, StringComparison.OrdinalIgnoreCase);
        }
    }
}