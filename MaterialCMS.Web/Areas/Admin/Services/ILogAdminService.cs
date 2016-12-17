using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Logging;
using MaterialCMS.Paging;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ILogAdminService
    {
        void Insert(Log log);
        IPagedList<Log> GetEntriesPaged(LogSearchQuery searchQuery);
        void DeleteAllLogs();
        void DeleteLog(Log log);
        List<SelectListItem> GetSiteOptions();
    }
}