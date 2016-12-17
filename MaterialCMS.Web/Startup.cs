using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using MaterialCMS.Web;
using MaterialCMS.Website;
using Owin;
using MaterialCMS.Helpers;
[assembly: OwinStartup(typeof(Startup))]
namespace MaterialCMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubActivator = new MaterialCMSHubActivator();

            GlobalHost.DependencyResolver.Register(
                typeof(IHubActivator),
                () => hubActivator);

            app.ConfigureAuth();
            
            ConfigureSignalR(app);
        }
        public static void ConfigureSignalR(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }

    public class MaterialCMSHubActivator : IHubActivator
    {
        public IHub Create(HubDescriptor descriptor)
        {
            return MaterialCMSApplication.Get(descriptor.HubType) as IHub;
        }
    }

}
