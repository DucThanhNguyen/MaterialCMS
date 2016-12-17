using System.Web.Mvc;
using MaterialCMS.Apps;
using MaterialCMS.Helpers;

namespace MaterialCMS.Website.Controllers
{
    public abstract class MaterialCMSAppAdminController<T> : MaterialCMSAdminController where T : MaterialCMSApp, new()
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RouteData.DataTokens["app"] = new T().AppName;
            base.OnActionExecuting(filterContext);
        }

        protected override void SetDefaultPageTitle(ActionExecutingContext filterContext)
        {
            ViewBag.Title = string.Format("{0} - {1} - {2}",
                                          new T().AppName.BreakUpString(),
                                          filterContext.RequestContext.RouteData.Values["controller"].ToString()
                                                                                                     .BreakUpString(),
                                          filterContext.RequestContext.RouteData.Values["action"].ToString()
                                                                                                 .BreakUpString());
        }
    }
}