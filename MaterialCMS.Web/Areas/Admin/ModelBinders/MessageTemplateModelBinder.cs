using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public abstract class MessageTemplateModelBinder : MaterialCMSDefaultModelBinder
    {
        private IMessageTemplateAdminService _messageTemplateAdminService;

        protected MessageTemplateModelBinder(IKernel kernel)
            : base(kernel)
        {
        }

        protected IMessageTemplateAdminService MessageTemplateAdminService
        {
            get { return _messageTemplateAdminService = _messageTemplateAdminService ?? Get<IMessageTemplateAdminService>(); }
        }
    }
}