using System.Collections.Generic;
using MaterialCMS.Entities.Messaging;
using MaterialCMS.Messages;

namespace MaterialCMS.Services
{
    public interface IEmailSender
    {
        bool CanSend(QueuedMessage queuedMessage);
        void SendMailMessage(QueuedMessage queuedMessage);
        void AddToQueue(QueuedMessage queuedMessage, List<AttachmentData> attachments = null);
    }
}