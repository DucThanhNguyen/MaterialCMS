using System.Web;
using System.Web.Mvc;

namespace MaterialCMS.Website.Profiling
{
    public class DisableMiniProfilerForAjaxRequests : IReasonToDisableMiniProfiler
    {
        public bool ShouldDisableFor(HttpRequest request)
        {
            return request.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}