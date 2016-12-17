using System;
using MaterialCMS.Website;

namespace MaterialCMS.Services.Notifications
{
    public class NotificationDisabler : IDisposable
    {
        private readonly bool _enableOnDispose;

        public NotificationDisabler()
        {
            if (!CurrentRequestData.CurrentContext.AreNotificationsDisabled())
            {
                _enableOnDispose = true;
                CurrentRequestData.CurrentContext.DisableNotifications();
            }
        }

        public void Dispose()
        {
            if (_enableOnDispose)
                CurrentRequestData.CurrentContext.EnableNotifications();
        }
    }
}