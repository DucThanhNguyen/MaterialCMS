using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IAdminUserStatsService
    {
        UserStats GetSummary();
    }
}