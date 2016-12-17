using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IAdminPageStatsService
    {
        IList<WebpageStats> GetSummary();
    }
}