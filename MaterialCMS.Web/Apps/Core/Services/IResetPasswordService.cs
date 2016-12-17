using MaterialCMS.Entities.People;
using MaterialCMS.Web.Apps.Core.Models;
using MaterialCMS.Web.Apps.Core.Models.RegisterAndLogin;

namespace MaterialCMS.Web.Apps.Core.Services
{
    public interface IResetPasswordService
    {
        void SetResetPassword(User user);
        void ResetPassword(ResetPasswordViewModel model);
    }
}