using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Services.ImportExport.DTOs;

namespace MaterialCMS.Services.ImportExport
{
    public interface IUpdateTagsService
    {
        void SetTags(DocumentImportDTO documentDto, Webpage webpage);
    }
}