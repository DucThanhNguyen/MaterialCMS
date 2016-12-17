using System.Collections.Generic;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Services.ImportExport.DTOs;

namespace MaterialCMS.Services.ImportExport
{
    public interface IImportDocumentsService
    {
        //void ImportDocumentsFromDTOs(IEnumerable<DocumentImportDTO> items);
        //Webpage ImportDocument(DocumentImportDTO dto);
        Batch CreateBatch(List<DocumentImportDTO> items, bool autoStart = true);
    }
}