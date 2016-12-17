using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class GetUrlGeneratorOptionsTypeModelBinder:MaterialCMSDefaultModelBinder
    {
        public GetUrlGeneratorOptionsTypeModelBinder(IKernel kernel) : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var typeName = GetValueFromContext(controllerContext, "type");
            return TypeHelper.GetTypeByName(typeName);
        }
    }
}