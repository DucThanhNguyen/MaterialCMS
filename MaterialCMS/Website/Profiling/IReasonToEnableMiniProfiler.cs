using System.Web;

namespace MaterialCMS.Website.Profiling
{
    public interface IReasonToEnableMiniProfiler
    {
        bool ShouldEnableFor(HttpRequest request);
    }
}