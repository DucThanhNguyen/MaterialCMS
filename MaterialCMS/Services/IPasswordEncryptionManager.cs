using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IPasswordEncryptionManager
    {
        void UpdateEncryption(User user, string password);
        void SetPassword(User user, string password);
        bool ValidateUser(User user, string password);
    }
}