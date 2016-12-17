using System;
using System.Web;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IUserLookup
    {
        User GetUserByEmail(string email);
        User GetUserByResetGuid(Guid resetGuid);
        User GetCurrentUser(HttpContextBase context);
    }
}