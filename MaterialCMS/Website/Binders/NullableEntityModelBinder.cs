using System;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Helpers;
using NHibernate;
using Ninject;

namespace MaterialCMS.Website.Binders
{
    public class NullableEntityModelBinder : MaterialCMSDefaultModelBinder
    {
        public NullableEntityModelBinder(IKernel kernel)
            : base(kernel)
        {
        }

        protected override bool ShouldReturnNull(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            const string baseId = "Id";
            var id = Convert.ToString(controllerContext.RouteData.Values[baseId] ??
                                      controllerContext.HttpContext.Request[baseId]);

            int intId;
            if (!int.TryParse(id, out intId) || intId <= 0)
            {
                return true;
            }
            return false;
        }
    }

}