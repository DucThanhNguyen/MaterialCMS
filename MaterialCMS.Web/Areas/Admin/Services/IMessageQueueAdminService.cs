using MaterialCMS.Entities.Messaging;
using MaterialCMS.Models;
using MaterialCMS.Paging;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IMessageQueueAdminService
    {
        IPagedList<QueuedMessage> GetMessages(MessageQueueQuery searchQuery);
        QueuedMessage GetMessageBody(int id);
    }
}