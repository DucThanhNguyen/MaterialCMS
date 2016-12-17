using System.Web.Mvc;
using MaterialCMS.Web.Apps.Core.Models.Search;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Apps.Core.ModelBinders
{
    public class WebpageSearchQueryModelBinder : MaterialCMSDefaultModelBinder
    {
        public WebpageSearchQueryModelBinder(IKernel kernel)
            : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int page;
            int.TryParse(GetValueFromContext(controllerContext, "page"), out page);
            if (page == 0)
                page = 1;
            return new WebpageSearchQuery
            {
                Page = page,
                Term = GetValueFromContext(controllerContext, "term")
            };
        }
    }
}