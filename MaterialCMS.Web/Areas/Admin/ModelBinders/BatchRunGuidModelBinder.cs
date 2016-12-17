using System;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Website.Binders;
using NHibernate.Linq;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class BatchRunGuidModelBinder : MaterialCMSDefaultModelBinder
    {
        public BatchRunGuidModelBinder(IKernel kernel)
            : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var id = Convert.ToString(controllerContext.RouteData.Values["id"]);
            Guid guid;
            if (Guid.TryParse(id, out guid))
            {
                return Session.Query<BatchRun>().FirstOrDefault(x => x.Guid == guid);
            }
            return null;
        }
    }
}