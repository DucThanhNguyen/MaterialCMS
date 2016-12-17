using System;
using System.Web;
using MaterialCMS.Helpers;

namespace MaterialCMS.Website.Profiling
{
    public class DisableMiniProfilerForSignalRRequests : IReasonToDisableMiniProfiler
    {
        public bool ShouldDisableFor(HttpRequest request)
        {
            return request.RawUrl.Contains("signalr", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}