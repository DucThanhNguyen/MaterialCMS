using System.Reflection;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Website;

namespace MaterialCMS.Helpers
{
    public static class WidgetCachingExtensions
    {
        public static bool IsTypeCachable(this Widget widget)
        {
            return widget.GetType().GetCustomAttribute<OutputCacheableAttribute>() != null;
        }
    }
}