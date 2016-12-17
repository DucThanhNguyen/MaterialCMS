using System;
using System.Web.Mvc;
using System.Web.Routing;
using MaterialCMS.Apps;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Helpers;
using MaterialCMS.Models;
using MaterialCMS.Services.Caching;

namespace MaterialCMS.Services
{
    public class WidgetUIService : IWidgetUIService
    {
        private readonly IGetWidgetCachingInfo _getWidgetCachingInfo;
        private readonly IHtmlCacheService _htmlCacheService;
        private readonly IWidgetModelService _widgetModelService;

        public WidgetUIService(IGetWidgetCachingInfo getWidgetCachingInfo,IHtmlCacheService htmlCacheService,IWidgetModelService widgetModelService)
        {
            _getWidgetCachingInfo = getWidgetCachingInfo;
            _htmlCacheService = htmlCacheService;
            _widgetModelService = widgetModelService;
        }

        public ActionResult GetContent(Controller controller, Widget widget, Func<HtmlHelper, MvcHtmlString> func)
        {
            return _htmlCacheService.GetContent(controller, _getWidgetCachingInfo.Get(widget), func);
        }

        public object GetModel(Widget widget)
        {
            return _widgetModelService.GetModel(widget);
        }

        public void SetAppDataToken(RouteData routeData, Widget widget)
        {
            if (MaterialCMSApp.AppWidgets.ContainsKey(widget.Unproxy().GetType()))
                routeData.DataTokens["app"] = MaterialCMSApp.AppWidgets[widget.Unproxy().GetType()];
        }
    }
}