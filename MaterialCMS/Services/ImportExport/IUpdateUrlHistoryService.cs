using System;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Services.ImportExport.DTOs;

namespace MaterialCMS.Services.ImportExport
{
    public interface IUpdateUrlHistoryService
    {
        void SetUrlHistory(DocumentImportDTO documentDto, Webpage webpage);
    }
}