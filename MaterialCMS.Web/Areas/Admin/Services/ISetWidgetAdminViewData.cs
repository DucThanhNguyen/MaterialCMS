using System.Web.Mvc;
using MaterialCMS.Entities.Widget;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ISetWidgetAdminViewData
    {
        void SetViewData<T>(T widget, ViewDataDictionary viewData) where T : Widget;
    }
}