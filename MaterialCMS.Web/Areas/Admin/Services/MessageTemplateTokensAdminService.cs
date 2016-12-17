using System.Collections.Generic;
using MaterialCMS.Messages;
using MaterialCMS.Services;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class MessageTemplateTokensAdminService : IMessageTemplateTokensAdminService
    {
        private readonly IMessageTemplateParser _messageTemplateParser;

        public MessageTemplateTokensAdminService(IMessageTemplateParser messageTemplateParser)
        {
            _messageTemplateParser = messageTemplateParser;
        }

        public List<string> GetTokens(MessageTemplate messageTemplate)
        {
            return _messageTemplateParser.GetAllTokens(messageTemplate);
        }
    }
}