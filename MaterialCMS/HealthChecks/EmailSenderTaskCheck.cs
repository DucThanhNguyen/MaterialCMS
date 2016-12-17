using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Helpers;
using MaterialCMS.Tasks;
using NHibernate;

namespace MaterialCMS.HealthChecks
{
    public class EmailSenderTaskCheck : HealthCheck
    {
        private readonly ITaskSettingManager _taskSettingManager;

        public EmailSenderTaskCheck(ITaskSettingManager taskSettingManager)
        {
            _taskSettingManager = taskSettingManager;
        }

        public override string DisplayName
        {
            get { return "Send email task setup"; }
        }

        public override HealthCheckResult PerformCheck()
        {
            var any = _taskSettingManager.GetInfo().Any(x => x.Type == typeof (SendQueuedMessagesTask) && x.Enabled);

            return !any
                ? new HealthCheckResult
                {
                    Messages = new List<string>
                    {
                        "Email sending task is not set up."
                    }
                }
                : HealthCheckResult.Success;
        }
    }
}