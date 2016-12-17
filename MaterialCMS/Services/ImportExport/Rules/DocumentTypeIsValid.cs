using System.Collections.Generic;
using MaterialCMS.Helpers;
using MaterialCMS.Services.ImportExport.DTOs;

namespace MaterialCMS.Services.ImportExport.Rules
{
    public class DocumentTypeIsValid : IDocumentImportValidationRule
    {
        public IEnumerable<string> GetErrors(DocumentImportDTO item, IList<DocumentImportDTO> allItems)
        {
            if (string.IsNullOrWhiteSpace(item.DocumentType) || DocumentMetadataHelper.GetTypeByName(item.DocumentType) == null)
                yield return "Document Type is not valid MaterialCMS type.";
        }
    }
}