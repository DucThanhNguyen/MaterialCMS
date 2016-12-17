using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IExternalUserSource
    {
        string Name { get; }
        User SynchroniseUser(string email);
        bool ValidateUser(User user, string password);
        void UpdateFromSource(User user);
    }
}