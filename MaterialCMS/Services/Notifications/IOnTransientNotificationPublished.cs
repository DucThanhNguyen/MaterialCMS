using MaterialCMS.Events;

namespace MaterialCMS.Services.Notifications
{
    public interface IOnTransientNotificationPublished : IEvent<OnTransientNotificationPublishedEventArgs>
    {
    }
}