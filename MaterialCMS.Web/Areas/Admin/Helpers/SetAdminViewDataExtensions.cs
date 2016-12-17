using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Areas.Admin.Helpers
{
    public static class SetAdminViewDataExtensions
    {
        public static void SetAdminViewData<T>(this T webpage, ViewDataDictionary viewDataDictionary) where T : Webpage
        {
            MaterialCMSApplication.Get<ISetWebpageAdminViewData>().SetViewData(webpage, viewDataDictionary);
        }

        public static void SetViewData<T>(this T widget, ViewDataDictionary viewDataDictionary) where T : Widget
        {
            MaterialCMSApplication.Get<ISetWidgetAdminViewData>().SetViewData(widget, viewDataDictionary);
        }
    }
}