using System.Collections.Generic;
using MaterialCMS.Entities.Messaging;
using MaterialCMS.Messages;

namespace MaterialCMS.Services
{
    public interface IQueueMessage
    {
        void Queue(QueuedMessage queuedMessage, List<AttachmentData> attachments = null, bool trySendImmediately = true);
    }
}