using MaterialCMS.Entities.Widget;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Core.Widgets
{
    [OutputCacheable(PerPage = true)]
    public class Navigation : Widget
    {
        public virtual bool IncludeChildren { get; set; }
    }
}