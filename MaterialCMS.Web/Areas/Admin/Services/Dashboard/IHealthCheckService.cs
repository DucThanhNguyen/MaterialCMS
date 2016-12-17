using System.Collections.Generic;
using System.Linq;
using MaterialCMS.HealthChecks;

namespace MaterialCMS.Web.Areas.Admin.Services.Dashboard
{
    public interface IHealthCheckService
    {
        List<IHealthCheck> GetHealthChecks();
    }

    public class HealthCheckService : IHealthCheckService
    {
        private readonly IEnumerable<IHealthCheck> _healthChecks;

        public HealthCheckService(IEnumerable<IHealthCheck> healthChecks)
        {
            _healthChecks = healthChecks;
      }

        public List<IHealthCheck> GetHealthChecks()
        {
            return _healthChecks.ToList();
        }
    }
}