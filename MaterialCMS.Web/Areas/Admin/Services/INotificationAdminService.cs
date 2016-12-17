using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Notifications;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Controllers;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface INotificationAdminService
    {
        IPagedList<Notification> Search(NotificationSearchQuery searchQuery);
        void PushNotification(PushNotificationModel model);
        List<SelectListItem> GetPublishTypeOptions();
        List<SelectListItem> GetNotificationTypeOptions(bool includeAnyOption = false);
        void Delete(Notification notification);
    }
}