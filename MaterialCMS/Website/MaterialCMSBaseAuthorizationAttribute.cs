using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Routing;

namespace MaterialCMS.Website
{
    public abstract class MaterialCMSBaseAuthorizationAttribute : AuthorizeAttribute
    {
        public bool ReturnEmptyResult { get; set; }
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (!CurrentRequestData.CurrentContext.Request.IsLocal && CurrentRequestData.SiteSettings.AllowedIPs.Any() &&
                !CurrentRequestData.SiteSettings.AllowedIPs.Contains(CurrentRequestData.CurrentContext.GetCurrentIP()))
                return false;
            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (ReturnEmptyResult || filterContext.IsChildAction)
            {
                filterContext.Result = new EmptyResult();
            }
            else
            {
                if (filterContext.Controller.GetType().GetCustomAttributes(typeof(MaterialCMSAuthorizeAttribute), true).Any())
                {
                    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        var routingErrorHandler = MaterialCMSApplication.Get<IMaterialCMSRoutingErrorHandler>();
                        var routeData = filterContext.RouteData;
                        routeData.Route = RouteTable.Routes.Last();
                        routeData.DataTokens.Remove("area");

                        var requestContext = new RequestContext(filterContext.HttpContext, routeData);
                        string message = string.Format("Not allowed to view {0}", requestContext.HttpContext.Request.Url);
                        var code = CurrentRequestData.CurrentUser != null ? 403 : 401;
                        routingErrorHandler.HandleError(requestContext, code, new HttpException(code, message));
                        
                        filterContext.Result = new EmptyResult();
                    }
                    else
                    {
                        base.HandleUnauthorizedRequest(filterContext);
                    }
                }
            }
        }
    }
}