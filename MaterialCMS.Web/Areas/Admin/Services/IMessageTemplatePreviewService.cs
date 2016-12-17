using MaterialCMS.Entities.Messaging;
using MaterialCMS.Messages;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IMessageTemplatePreviewService
    {
        MessageTemplate GetTemplate(string type);
        QueuedMessage GetPreview(string type, int id);
    }
}