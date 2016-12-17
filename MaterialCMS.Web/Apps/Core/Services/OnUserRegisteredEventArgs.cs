using System;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Web.Apps.Core.Services
{
    public class OnUserRegisteredEventArgs
    {
       public OnUserRegisteredEventArgs(User user, Guid previousSession)
        {
            User = user;
            PreviousSession = previousSession;
        }

        public User User { get; set; }
        public Guid PreviousSession { get; set; }
    }
}