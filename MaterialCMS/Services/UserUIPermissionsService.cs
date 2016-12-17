using System.Linq;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.People;
using MaterialCMS.Helpers;

namespace MaterialCMS.Services
{
    public class UserUIPermissionsService : IUserUIPermissionsService
    {
        private readonly IGetCurrentUser _getCurrentUser;

        public UserUIPermissionsService(IGetCurrentUser getCurrentUser)
        {
            _getCurrentUser = getCurrentUser;
        }

        public bool IsCurrentUserAllowed(Webpage webpage)
        {
            User user = _getCurrentUser.Get();
            if (user != null && user.IsAdmin) return true;
            if (webpage.InheritFrontEndRolesFromParent)
            {
                if (webpage.Parent is Webpage)
                    return IsCurrentUserAllowed(webpage.Parent as Webpage);
                return true;
            }
            if (!webpage.FrontEndAllowedRoles.Any()) return true;
            if (webpage.FrontEndAllowedRoles.Any() && user == null) return false;
            return user != null && user.Roles.Intersect(webpage.FrontEndAllowedRoles).Any();
        }
    }
}