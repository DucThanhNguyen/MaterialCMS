using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Entities.People;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Areas.Admin.Hubs
{
    [MaterialCMSAuthorize]
    [HubName("notifications")]
    public class NotificationHub : Hub
    {
        public const string UsersGroup = "Users";
        public const string AdminGroup = "Admins";
        private readonly INotificationHubService _notificationHubService;

        public NotificationHub(INotificationHubService notificationHubService)
        {
            _notificationHubService = notificationHubService;
        }

        public override Task OnConnected()
        {
            User user = _notificationHubService.GetUser(Context.User);
            return user == null || !user.IsAdmin
                ? Groups.Add(Context.ConnectionId, UsersGroup)
                : Groups.Add(Context.ConnectionId, AdminGroup);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            User user = _notificationHubService.GetUser(Context.User);
            return user == null || !user.IsAdmin
                ? Groups.Remove(Context.ConnectionId, UsersGroup)
                : Groups.Remove(Context.ConnectionId, AdminGroup);
        }
    }

    public class MaterialCMSAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool UserAuthorized(IPrincipal user)
        {
            User currentUser = CurrentRequestData.CurrentUser;
            return base.UserAuthorized(user) && currentUser != null &&
                   currentUser.IsActive &&
                   currentUser.Email != null &&
                   currentUser.Email.Equals(user.Identity.Name, StringComparison.OrdinalIgnoreCase) &&
                   currentUser.CanAccess<AdminAccessACL>(AdminAccessACL.Allowed);
        }
    }
}