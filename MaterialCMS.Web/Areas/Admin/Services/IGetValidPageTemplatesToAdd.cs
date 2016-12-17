using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IGetValidPageTemplatesToAdd
    {
        List<PageTemplate> Get(IEnumerable<DocumentMetadata> validWebpageDocumentTypes);
    }
}