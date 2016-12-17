using System.Web.Mvc;
using MaterialCMS.Settings;
using MaterialCMS.Website.Binders;
using NHibernate;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class ThirdPartyAuthSettingsModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly ISystemConfigurationProvider _configurationProvider;

        public ThirdPartyAuthSettingsModelBinder(IKernel kernel, ISystemConfigurationProvider configurationProvider) : base(kernel)
        {
            _configurationProvider = configurationProvider;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, System.Type modelType)
        {
            return _configurationProvider.GetSystemSettings<ThirdPartyAuthSettings>();
        }
    }
}