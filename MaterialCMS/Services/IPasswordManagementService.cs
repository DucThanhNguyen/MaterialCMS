using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IPasswordManagementService
    {
        bool ValidatePassword(string password, string confirmation);
        void SetPassword(User user, string password, string confirmation);
        bool ValidateUser(User user, string password);
    }
}