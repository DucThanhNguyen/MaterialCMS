using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class MessageTemplatePreviewController : MaterialCMSAdminController
    {
        private readonly IMessageTemplatePreviewService _messageTemplatePreviewService;

        public MessageTemplatePreviewController(IMessageTemplatePreviewService messageTemplatePreviewService)
        {
            _messageTemplatePreviewService = messageTemplatePreviewService;
        }

        public ViewResult Get(string type)
        {
            return View(_messageTemplatePreviewService.GetTemplate(type));
        }

        public PartialViewResult Preview(string type, int id)
        {
            return PartialView(_messageTemplatePreviewService.GetPreview(type, id));
        }
    }
}