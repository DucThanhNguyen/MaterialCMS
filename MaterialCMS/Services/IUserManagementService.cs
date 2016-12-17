using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IUserManagementService
    {
        void AddUser(User user);
        void SaveUser(User user);
        User GetUser(int id);
        void DeleteUser(User user);
        bool IsUniqueEmail(string email, int? id = null);
    }
}