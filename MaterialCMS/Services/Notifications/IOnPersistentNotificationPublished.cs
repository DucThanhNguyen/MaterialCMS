using MaterialCMS.Events;

namespace MaterialCMS.Services.Notifications
{
    public interface IOnPersistentNotificationPublished : IEvent<OnPersistentNotificationPublishedEventArgs>
    {
    }
}