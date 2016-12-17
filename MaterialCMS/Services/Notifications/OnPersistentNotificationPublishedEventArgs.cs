using MaterialCMS.Entities.Notifications;

namespace MaterialCMS.Services.Notifications
{
    public class OnPersistentNotificationPublishedEventArgs
    {
        public OnPersistentNotificationPublishedEventArgs(Notification notification)
        {
            Notification = notification;
        }

        public Notification Notification { get; set; }
    }
}