using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IWebpageWidgetAdminService
    {
        void Hide(Webpage webpage, int widgetId);
        void Show(Webpage webpage, int widgetId);
    }
}