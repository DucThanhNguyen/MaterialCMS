using MaterialCMS.Entities.People;
using MaterialCMS.Web.Areas.Admin.Controllers;
using MaterialCMS.Web.Areas.Admin.Models;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class AdminUserStatsService : IAdminUserStatsService
    {
        private readonly ISession _session;

        public AdminUserStatsService(ISession session)
        {
            _session = session;
        }

        public UserStats GetSummary()
        {
            return new UserStats
                   {
                       ActiveUsers = _session.QueryOver<User>().Where(x => x.IsActive).Cacheable().RowCount(),
                       InactiveUsers = _session.QueryOver<User>().WhereNot(x => x.IsActive).Cacheable().RowCount()
                   };
        }
    }
}