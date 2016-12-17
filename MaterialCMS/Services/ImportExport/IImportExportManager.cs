using System.Collections.Generic;
using System.IO;
using MaterialCMS.Models;

namespace MaterialCMS.Services.ImportExport
{
    public interface IImportExportManager
    {
        byte[] ExportDocumentsToExcel();
        ImportDocumentsResult ImportDocumentsFromExcel(Stream file, bool autoStart = true);
        ExportDocumentsResult ExportDocumentsToEmail(ExportDocumentsModel model);
    }
}