using System.Collections.Generic;
using MaterialCMS.Messages;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IMessageTemplateTokensAdminService
    {
        List<string> GetTokens(MessageTemplate messageTemplate);
    }
}