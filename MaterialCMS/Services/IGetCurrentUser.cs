using MaterialCMS.Entities.People;

namespace MaterialCMS.Services
{
    public interface IGetCurrentUser
    {
        User Get();
    }
}