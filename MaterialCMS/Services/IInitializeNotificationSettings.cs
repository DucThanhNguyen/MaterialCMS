using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IInitializeNotificationSettings
    {
        void InitializeUserSettings(User user);
    }
}