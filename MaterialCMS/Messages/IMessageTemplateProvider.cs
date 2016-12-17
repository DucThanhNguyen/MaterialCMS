using System;
using System.Collections.Generic;
using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Messages
{
    public interface IMessageTemplateProvider
    {
        void SaveTemplate(MessageTemplate messageTemplate);
        void SaveSiteOverride(MessageTemplate messageTemplate, Site site);
        void DeleteSiteOverride(MessageTemplate messageTemplate, Site site);
        List<MessageTemplate> GetAllMessageTemplates(Site site);
        T GetMessageTemplate<T>(Site site) where T : MessageTemplate, new();
        MessageTemplate GetNewMessageTemplate(Type type);
    }
}