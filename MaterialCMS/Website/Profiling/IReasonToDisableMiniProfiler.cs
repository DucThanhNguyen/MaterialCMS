using System.Web;

namespace MaterialCMS.Website.Profiling
{
    public interface IReasonToDisableMiniProfiler
    {
        bool ShouldDisableFor(HttpRequest request);
    }
}