using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IDocumentRolesAdminService
    {
        void SetFrontEndRoles(string frontEndRoles, Webpage webpage);
    }
}