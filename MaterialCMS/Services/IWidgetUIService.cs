using System;
using System.Web.Mvc;
using System.Web.Routing;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Models;

namespace MaterialCMS.Services
{
    public interface IWidgetUIService
    {
        ActionResult GetContent(Controller controller, Widget widget, Func<HtmlHelper, MvcHtmlString> func);
        object GetModel(Widget widget);
        void SetAppDataToken(RouteData routeData, Widget widget);
    }
}