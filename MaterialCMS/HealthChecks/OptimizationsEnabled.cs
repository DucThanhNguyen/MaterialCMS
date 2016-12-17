using System.Collections.Generic;
using MaterialCMS.Services.Resources;
using MaterialCMS.Settings;

namespace MaterialCMS.HealthChecks
{
    public class OptimizationsEnabled : HealthCheck
    {
        private readonly BundlingSettings _bundlingSettings;
        private readonly IStringResourceProvider _stringResourceProvider;

        public OptimizationsEnabled(BundlingSettings bundlingSettings, IStringResourceProvider stringResourceProvider)
        {
            _bundlingSettings = bundlingSettings;
            _stringResourceProvider = stringResourceProvider;
        }

        public override HealthCheckResult PerformCheck()
        {
            if (_bundlingSettings.EnableOptimisations)
                return HealthCheckResult.Success;

            return new HealthCheckResult
            {
                Status = HealthCheckStatus.Warning,
                Messages = new List<string>
                {
                    _stringResourceProvider.GetValue("Please enable optimizations in system settings.")
                }
            };
        }
    }
}