using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Settings;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MaterialCMS.IoC.Modules
{
    //Wires up IOC automatically

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(syntax => syntax.From(TypeHelper.GetAllMaterialCMSAssemblies()).SelectAllClasses()
                .Where(
                    t =>
                        !typeof(SiteSettingsBase).IsAssignableFrom(t) &&
                        !typeof(SystemSettingsBase).IsAssignableFrom(t) &&
                        !typeof(IController).IsAssignableFrom(t) && !Kernel.GetBindings(t).Any())
                .BindWith<NinjectServiceToInterfaceBinder>()
                .Configure(onSyntax => onSyntax.InRequestScope()));


        }
    }
}