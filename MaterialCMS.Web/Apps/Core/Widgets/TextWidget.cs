using System.Web.Mvc;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Core.Widgets
{
    [OutputCacheable]
    public class TextWidget : Widget
    {
        [AllowHtml]
        public virtual string Text { get; set; }
    }
}
