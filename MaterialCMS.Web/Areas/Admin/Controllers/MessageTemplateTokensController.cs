using System.Web.Mvc;
using MaterialCMS.Messages;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class MessageTemplateTokensController : MaterialCMSAdminController
    {
        private readonly IMessageTemplateTokensAdminService _messageTemplateTokensAdminService;

        public MessageTemplateTokensController(IMessageTemplateTokensAdminService messageTemplateTokensAdminService)
        {
            _messageTemplateTokensAdminService = messageTemplateTokensAdminService;
        }

        public PartialViewResult Tokens(MessageTemplate messageTemplate)
        {
            return PartialView(_messageTemplateTokensAdminService.GetTokens(messageTemplate));
        }
    }
}