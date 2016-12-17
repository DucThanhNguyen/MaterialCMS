using System.Collections.Generic;
using MaterialCMS.Services.ImportExport.DTOs;

namespace MaterialCMS.Services.ImportExport.Rules
{
    public interface IDocumentImportValidationRule
    {
        IEnumerable<string> GetErrors(DocumentImportDTO item, IList<DocumentImportDTO> allItems);
    }
}