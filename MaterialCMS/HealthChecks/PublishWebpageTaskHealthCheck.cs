using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Helpers;
using MaterialCMS.Tasks;
using NHibernate;

namespace MaterialCMS.HealthChecks
{
    public class PublishWebpageTaskHealthCheck : HealthCheck
    {
        private readonly ITaskSettingManager _taskSettingManager;

        public PublishWebpageTaskHealthCheck(ITaskSettingManager taskSettingManager)
        {
            _taskSettingManager = taskSettingManager;
        }

        public override string DisplayName
        {
            get { return "Page Publisher task setup"; }
        }

        public override HealthCheckResult PerformCheck()
        {
            var any = _taskSettingManager.GetInfo().Any(x => x.Type == typeof(PublishScheduledWebpagesTask) && x.Enabled);

            return !any
                ? new HealthCheckResult
                {
                    Messages = new List<string>
                    {
                        "Publisher task is not set up."
                    }
                }
                : HealthCheckResult.Success;
        }
    }
}