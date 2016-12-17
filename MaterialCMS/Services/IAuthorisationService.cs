using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IAuthorisationService
    {
        Task SetAuthCookie(User user, bool rememberMe);
        void Logout();
        Task UpdateClaimsAsync(User user, IEnumerable<Claim> claims);
    }
}