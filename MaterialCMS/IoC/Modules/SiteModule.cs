using MaterialCMS.Entities.Multisite;
using MaterialCMS.Website;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MaterialCMS.IoC.Modules
{
    public class SiteModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Rebind<Site>()
                .ToMethod(context => CurrentRequestData.CurrentSite)
                .InRequestScope();
        }
    }
}