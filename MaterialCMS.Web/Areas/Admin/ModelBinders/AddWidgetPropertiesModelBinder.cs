using System;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class AddWidgetPropertiesModelBinder : MaterialCMSDefaultModelBinder
    {
        public AddWidgetPropertiesModelBinder(IKernel kernel) : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var typeName =
                GetValueFromContext(controllerContext, "type").Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries)
                    [0];
            var entityType = TypeHelper.MappedClasses.FirstOrDefault(type => type.FullName == typeName);

            if (entityType != null && entityType.HasDefaultConstructor())
            {
                return Activator.CreateInstance(entityType) as Widget;
            }
            return null;
        }
    }
}