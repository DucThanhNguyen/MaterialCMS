using MaterialCMS.Entities.Notifications;

namespace MaterialCMS.Services.Notifications
{
    public class OnTransientNotificationPublishedEventArgs
    {
        public OnTransientNotificationPublishedEventArgs(Notification notification)
        {
            Notification = notification;
        }

        public Notification Notification { get; set; }
    }
}