using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MaterialCMS.Apps;
using MaterialCMS.DbConfiguration;
using MaterialCMS.DbConfiguration.Caches;
using MaterialCMS.DbConfiguration.Caches.Redis;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Messages;
using MaterialCMS.Settings;
using MaterialCMS.Tasks;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Caching;
using MaterialCMS.Website.Filters;
using MaterialCMS.Website.Routing;
using NHibernate;
using NHibernate.Caches.Redis;
using Ninject;
using StackExchange.Profiling;

namespace MaterialCMS.Website
{
    public abstract class MaterialCMSApplication : HttpApplication
    {
        public const string AssemblyVersion = "1.0.0.0";
        public const string AssemblyFileVersion = "1.0.0.0";
        private const string CachedMissingItemKey = "cached-missing-item";


        private static IOnEndRequestExecutor OnEndRequestExecutor
        {
            get { return MaterialCMSKernel.Kernel.Get<IOnEndRequestExecutor>(); }
        }

        protected void Application_Start()
        {
            MaterialCMSApp.RegisterAllApps();
            AreaRegistration.RegisterAllAreas(MaterialCMSKernel.Kernel);
            MaterialCMSRouteRegistration.Register(RouteTable.Routes);

            RegisterServices(MaterialCMSKernel.Kernel);
            MaterialCMSApp.RegisterAllServices(MaterialCMSKernel.Kernel);

            LegacySettingMigrator.MigrateSettings(MaterialCMSKernel.Kernel);
            LegacyTemplateMigrator.MigrateTemplates(MaterialCMSKernel.Kernel);

            SetModelBinders();

            SetViewEngines();

            BundleRegistration.Register(MaterialCMSKernel.Kernel);

            ControllerBuilder.Current.SetControllerFactory(new MaterialCMSControllerFactory());

            GlobalFilters.Filters.Add(new HoneypotFilterAttribute());

            ModelMetadataProviders.Current = new MaterialCMSMetadataProvider(MaterialCMSKernel.Kernel);

            ImagePluginInstaller.Install();

            MiniProfiler.Settings.Results_Authorize = MiniProfilerAuth.IsUserAllowedToSeeMiniProfilerUI;
            MiniProfiler.Settings.Results_List_Authorize = MiniProfilerAuth.IsUserAllowedToSeeMiniProfilerUI;


            OnApplicationStart();
        }

        protected void Application_End()
        {
            if (RedisCacheInitializer.Initialized)
                RedisCacheInitializer.Dispose();
        }



        protected virtual void SetViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Insert(0, new MaterialCMSRazorViewEngine());
        }

        protected virtual void OnApplicationStart()
        {
        }

        protected virtual void SetModelBinders()
        {
            ModelBinders.Binders.DefaultBinder = new MaterialCMSDefaultModelBinder(MaterialCMSKernel.Kernel);
            ModelBinders.Binders.Add(typeof(DateTime), new CultureAwareDateBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableCultureAwareDateBinder());
        }


        public override void Init()
        {
            if (CurrentRequestData.DatabaseIsInstalled)
            {
                BeginRequest += (sender, args) =>
                {
                    if (IsCachedMissingFileRequest())
                        return;
                    RequestInitializer.Initialize(Request);

                    OnBeginRequest(sender, args);
                };
                AuthenticateRequest += (sender, args) =>
                {
                    if (!Context.Items.Contains(CachedMissingItemKey) && !RequestInitializer.IsFileRequest(Request.Url))
                    {
                        RequestAuthenticator.Authenticate(Request);
                    }
                    OnAuthenticateRequest(sender, args);
                };
                EndRequest += (sender, args) =>
                {
                    if (Context.Items.Contains(CachedMissingItemKey))
                        return;

                    OnEndRequestExecutor.ExecuteTasks(CurrentRequestData.OnEndRequest);

                    OnEndRequest(sender, args);

                    MiniProfiler.Stop();
                };
            }
            else
            {
                EndRequest += (sender, args) => OnEndRequestExecutor.ExecuteTasks(CurrentRequestData.OnEndRequest);
            }
        }

        protected virtual void OnEndRequest(object sender, EventArgs args)
        {
        }

        protected virtual void OnAuthenticateRequest(object sender, EventArgs args)
        {
        }

        protected virtual void OnBeginRequest(object sender, EventArgs args)
        {
        }

        private bool IsCachedMissingFileRequest()
        {
            string missingFile =
                Convert.ToString(
                    Get<ICacheWrapper>()[FileNotFoundHandler.GetMissingFileCacheKey(new HttpRequestWrapper(Request))]);
            if (!string.IsNullOrWhiteSpace(missingFile))
            {
                Context.Items[CachedMissingItemKey] = true;
                Context.Response.Clear();
                Context.Response.StatusCode = 404;
                Context.Response.TrySkipIisCustomErrors = true;
                Context.Response.Write(missingFile);
                Context.ApplicationInstance.CompleteRequest();
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Load your modules or register your non-app specific services here
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        protected virtual void RegisterServices(IKernel kernel)
        {
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return MaterialCMSKernel.Kernel.GetAll<T>();
        }

        public static T Get<T>()
        {
            return MaterialCMSKernel.Kernel.Get<T>();
        }

        public static object Get(Type type)
        {
            return MaterialCMSKernel.Kernel.Get(type);
        }
    }
}