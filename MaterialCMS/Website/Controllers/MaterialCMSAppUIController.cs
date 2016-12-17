using System.Web.Mvc;
using MaterialCMS.Apps;

namespace MaterialCMS.Website.Controllers
{
    public abstract class MaterialCMSAppUIController<T> : MaterialCMSUIController where T : MaterialCMSApp, new()
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RouteData.DataTokens["app"] = new T().AppName;
            base.OnActionExecuting(filterContext);
        }
    }
}