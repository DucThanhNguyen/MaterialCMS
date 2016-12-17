using System.Web.Mvc;
using MaterialCMS.Settings;

namespace MaterialCMS.Website.Filters
{
    public class HoneypotFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CurrentRequestData.DatabaseIsInstalled) return;
            if (!string.IsNullOrWhiteSpace(
                filterContext.HttpContext.Request[MaterialCMSApplication.Get<SiteSettings>().HoneypotFieldName]))
            {
                filterContext.Result = new EmptyResult();
            }
        }
    }
}