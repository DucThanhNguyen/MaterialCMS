using MaterialCMS.Services;
using MaterialCMS.Website;
using Owin;

namespace MaterialCMS.Helpers
{
    public static class AuthConfigurationServiceExtensions
    {
        public static void ConfigureAuth(this IAppBuilder app)
        {
            var standardAuthConfigurationService = MaterialCMSApplication.Get<IStandardAuthConfigurationService>();
            standardAuthConfigurationService.ConfigureAuth(app);
            if (CurrentRequestData.DatabaseIsInstalled)
            {
                var authConfigurationService = MaterialCMSApplication.Get<IAuthConfigurationService>();
                authConfigurationService.ConfigureAuth(app);
            }
        }
    }
}