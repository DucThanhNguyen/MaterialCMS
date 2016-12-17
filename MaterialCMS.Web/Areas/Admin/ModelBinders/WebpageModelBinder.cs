using System.Web.Mvc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public abstract class WebpageModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly IDocumentTagsAdminService _documentTagsAdminService;

        protected WebpageModelBinder(IKernel kernel, IDocumentTagsAdminService documentTagsAdminService)
            : base(kernel)
        {
            _documentTagsAdminService = documentTagsAdminService;
        }

        protected IDocumentTagsAdminService DocumentTagsAdminService
        {
            get { return _documentTagsAdminService; }
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var document = base.BindModel(controllerContext, bindingContext) as Document;
            string taglist = controllerContext.GetValueFromRequest("TagList") ?? string.Empty;
            DocumentTagsAdminService.SetTags(taglist, document);
            return document;
        }
    }
}