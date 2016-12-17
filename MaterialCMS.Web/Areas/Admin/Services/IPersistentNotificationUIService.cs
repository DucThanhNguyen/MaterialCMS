using System.Collections.Generic;
using MaterialCMS.Web.Areas.Admin.Models.Notifications;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IPersistentNotificationUIService
    {
        IList<NotificationModel> GetNotifications();
        int GetNotificationCount();
        void MarkAllAsRead();
    }
}