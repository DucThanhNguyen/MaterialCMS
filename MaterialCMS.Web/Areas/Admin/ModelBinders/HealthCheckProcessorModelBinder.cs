using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class HealthCheckProcessorModelBinder : MaterialCMSDefaultModelBinder
    {
        public HealthCheckProcessorModelBinder(IKernel kernel) : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string typeName = GetValueFromContext(controllerContext, "typeName");
            var typeByName = TypeHelper.GetTypeByName(typeName);
            return typeName == null ? null : Kernel.Get(typeByName);
        }
    }
}