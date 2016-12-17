using Owin;

namespace MaterialCMS.Services
{
    public interface IAuthConfigurationService
    {
        void ConfigureAuth(IAppBuilder app);
    }
}