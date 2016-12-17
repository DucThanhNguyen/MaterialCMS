using MaterialCMS.DbConfiguration.Mapping;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Core.Widgets
{
    [OutputCacheable]
    public class PlainTextWidget : Widget
    {
        public virtual string Text { get; set; }
    }
}