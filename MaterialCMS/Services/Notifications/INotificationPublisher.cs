using MaterialCMS.Entities.Notifications;

namespace MaterialCMS.Services.Notifications
{
    public interface INotificationPublisher
    {
        void PublishNotification(string message, PublishType publishType = PublishType.Both,
                                 NotificationType notificationType = NotificationType.All);
    }
}