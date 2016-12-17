using System.Security.Principal;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface INotificationHubService
    {
        User GetUser(IPrincipal user);
    }
}