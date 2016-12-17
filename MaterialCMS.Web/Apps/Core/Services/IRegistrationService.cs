using System.Threading.Tasks;
using MaterialCMS.Entities.People;
using MaterialCMS.Web.Apps.Core.Models;
using MaterialCMS.Web.Apps.Core.Models.RegisterAndLogin;

namespace MaterialCMS.Web.Apps.Core.Services
{
    public interface IRegistrationService
    {
        Task<User> RegisterUser(RegisterModel model);
        bool CheckEmailIsNotRegistered(string email);
    }
}