using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website
{
    public class HandleWebpageViewsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResult;
            if (result == null) return;
            var webpage = result.Model as Webpage;
            if (webpage == null) return;
            MaterialCMSApplication.Get<IProcessWebpageViews>().Process(result, webpage);
        }
    }
}