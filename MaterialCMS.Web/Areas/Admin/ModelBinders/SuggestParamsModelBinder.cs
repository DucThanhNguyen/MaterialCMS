using System;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Models;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class SuggestParamsModelBinder : MaterialCMSDefaultModelBinder
    {
        public SuggestParamsModelBinder(IKernel kernel)
            : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext) as SuggestParams;
            if (model == null) return null;

            var documentType = model.DocumentType;
            var parts = documentType.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Count() == 1)
            {
                return model;
            }
            model.DocumentType = parts[0];
            int id;
            model.Template = int.TryParse(parts[1], out id) ? id : (int?)null;
            return model;
        }
    }
}