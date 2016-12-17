using System.Web.Mvc;
using MaterialCMS.Services;

namespace MaterialCMS.Website.Filters
{
    public class EnsureHomePageIsSet : ActionFilterAttribute
    {
        private IGetHomePage _getHomePage;

        public IGetHomePage GetHomePage
        {
            get { return _getHomePage ?? MaterialCMSApplication.Get<IGetHomePage>(); }
            set { _getHomePage = value; }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentRequestData.HomePage == null)
                CurrentRequestData.HomePage = GetHomePage.Get();
        }
    }
}