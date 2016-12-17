using MaterialCMS.Entities.Documents;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IDocumentTagsAdminService
    {
        void SetTags(string taglist, int id);
        void SetTags(string taglist, Document document);
    }
}