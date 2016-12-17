using System.Collections.Generic;
using MaterialCMS.Services;

namespace MaterialCMS.Entities.Messaging
{
    public interface IMessageTemplate<T>
    {
        List<string> GetTokens(IMessageTemplateParser messageTemplateParser);
    }
}