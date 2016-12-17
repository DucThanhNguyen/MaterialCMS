using System.Web.Mvc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Services;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class EditWebpageModelBinder : WebpageModelBinder
    {
        private readonly IDocumentRolesAdminService _documentRolesAdminService;

        public EditWebpageModelBinder(IDocumentRolesAdminService documentRolesAdminService, IKernel kernel,
            IDocumentTagsAdminService documentTagsAdminService)
            : base(kernel, documentTagsAdminService)
        {
            _documentRolesAdminService = documentRolesAdminService;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var document = base.BindModel(controllerContext, bindingContext) as Document;

            if (document is Webpage)
            {
                string frontEndRoles = GetValueFromContext(controllerContext, "FrontEndRoles");
                _documentRolesAdminService.SetFrontEndRoles(frontEndRoles, document as Webpage);
            }

            return document;
        }
    }
}