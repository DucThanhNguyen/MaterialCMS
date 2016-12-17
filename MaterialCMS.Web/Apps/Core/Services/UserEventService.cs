using System;
using MaterialCMS.Entities.People;
using MaterialCMS.Events;

namespace MaterialCMS.Web.Apps.Core.Services
{
    /// <summary>
    ///     Event that passes in the user object and the guid of the anonymous user guid that the user was using before login.
    ///     Allows the copying of data from the anonymous user to the existing one
    /// </summary>
    public interface IOnUserLoggedIn : IEvent<UserLoggedInEventArgs>
    {
    }

    public class UserLoggedInEventArgs : EventArgs
    {
        public UserLoggedInEventArgs(User user, Guid previousSession)
        {
            User = user;
            PreviousSession = previousSession;
        }

        public User User { get; set; }
        public Guid PreviousSession { get; set; }
    }
}