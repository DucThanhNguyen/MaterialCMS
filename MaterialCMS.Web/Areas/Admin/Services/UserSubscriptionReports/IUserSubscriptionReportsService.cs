using System.Collections.Generic;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Models.UserSubscriptionReports;

namespace MaterialCMS.Web.Areas.Admin.Services.UserSubscriptionReports
{
    public interface IUserSubscriptionReportsService
    {
        IEnumerable<LineGraphData> GetAllSubscriptions(UserSubscriptionReportsSearchQuery searchQuery);
    }
}