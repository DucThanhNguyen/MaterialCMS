using MaterialCMS.Entities.Widget;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Core.Widgets
{
    [OutputCacheable]
    public class LinkedImage : Widget 
    {
        public virtual string Image { get; set; }
        public virtual string Link { get; set; }
    }
}