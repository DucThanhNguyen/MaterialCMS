using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using OfficeOpenXml;

namespace MaterialCMS.Services.ImportExport
{
    public interface IExportDocumentsService
    {
        ExcelPackage GetExportExcelPackage(List<Webpage> webpages);
        byte[] ConvertPackageToByteArray(ExcelPackage package);
    }
}