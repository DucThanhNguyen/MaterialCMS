using System.Collections.Generic;
using MaterialCMS.Entities.Documents;

namespace MaterialCMS.Services
{
    public interface IGetDocumentParents
    {
        IEnumerable<T> GetDocumentsByParent<T>(T parent) where T : Document;
    }
}