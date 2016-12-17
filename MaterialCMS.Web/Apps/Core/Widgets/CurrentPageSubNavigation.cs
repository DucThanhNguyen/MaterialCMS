using System.ComponentModel;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Core.Widgets
{
    [OutputCacheable(PerPage = true)]
    public class CurrentPageSubNavigation : Widget
    {
        [DisplayName("Show Name As Title")]
        public virtual bool ShowNameAsTitle { get; set; }
    }
}