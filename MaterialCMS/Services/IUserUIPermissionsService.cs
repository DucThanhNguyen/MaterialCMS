using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    public interface IUserUIPermissionsService
    {
        bool IsCurrentUserAllowed(Webpage webpage);
    }
}