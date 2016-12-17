using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services.ImportExport
{
    public interface IUrlHistoryImportService
    {
        List<UrlHistoryInfo> GetAllOtherUrls(Webpage webpage);
    }
}