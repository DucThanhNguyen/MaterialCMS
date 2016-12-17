using MaterialCMS.Apps;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Installation;
using NHibernate;
using Ninject;

namespace MaterialCMS.Web.Apps.Galleries
{
    public class GalleriesApp : MaterialCMSApp
    {
        public override string AppName
        {
            get { return "Galleries"; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        protected override void RegisterServices(IKernel kernel)
        {
            
        }

        protected override void RegisterApp(MaterialCMSAppRegistrationContext context)
        {
        }
    }
}