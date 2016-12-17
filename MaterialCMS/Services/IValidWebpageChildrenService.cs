using System.Collections.Generic;
using Antlr.Runtime.Misc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    public interface IValidWebpageChildrenService
    {
        IEnumerable<DocumentMetadata> GetValidWebpageDocumentTypes(Webpage webpage, Func<DocumentMetadata, bool> predicate = null);
        bool AnyValidWebpageDocumentTypes(Webpage webpage, Func<DocumentMetadata, bool> predicate = null);
    }
}