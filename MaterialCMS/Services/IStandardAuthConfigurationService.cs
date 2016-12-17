using Owin;

namespace MaterialCMS.Services
{
    public interface IStandardAuthConfigurationService
    {
        void ConfigureAuth(IAppBuilder app);
    }
}