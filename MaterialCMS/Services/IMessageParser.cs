using System.Collections.Generic;
using MaterialCMS.Entities.Messaging;
using MaterialCMS.Messages;

namespace MaterialCMS.Services
{
    public interface IMessageParser<T, in T2> where T : MessageTemplate<T2>, new()
    {
        QueuedMessage GetMessage(T2 obj, string fromAddress = null, string fromName = null, string toAddress = null,
            string toName = null,
            string cc = null, string bcc = null);

        void QueueMessage(QueuedMessage queuedMessage, List<AttachmentData> attachments = null, bool trySendImmediately = true);

    }

    public interface IMessageParser<T> where T : MessageTemplate, new()
    {
        QueuedMessage GetMessage(string fromAddress = null, string fromName = null, string toAddress = null,
            string toName = null,
            string cc = null, string bcc = null);

        void QueueMessage(QueuedMessage queuedMessage, List<AttachmentData> attachments = null, bool trySendImmediately = true);
    }
}