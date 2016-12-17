using MaterialCMS.Entities.Widget;
using MaterialCMS.Models;

namespace MaterialCMS.Services
{
    public interface IGetWidgetCachingInfo
    {
        CachingInfo Get(Widget widget);
    }
}