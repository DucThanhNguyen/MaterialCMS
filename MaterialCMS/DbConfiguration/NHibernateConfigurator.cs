using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MaterialCMS.Apps;
using MaterialCMS.Batching.Entities;
using MaterialCMS.DbConfiguration.Caches;
using MaterialCMS.DbConfiguration.Configuration;
using MaterialCMS.DbConfiguration.Conventions;
using MaterialCMS.DbConfiguration.Filters;
using MaterialCMS.DbConfiguration.Mapping;
using MaterialCMS.Entities;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Documents.Web.FormProperties;
using MaterialCMS.Entities.People;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Helpers;
using MaterialCMS.Website;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Caches.SysCache2;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using Environment = NHibernate.Cfg.Environment;

namespace MaterialCMS.DbConfiguration
{
    public class NHibernateConfigurator
    {
        private readonly IDatabaseProvider _databaseProvider;

        public NHibernateConfigurator(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
            CacheEnabled = true;
        }

        public bool CacheEnabled { get; set; }

        public List<Assembly> ManuallyAddedAssemblies { get; set; }

        public ISessionFactory CreateSessionFactory()
        {
            var configuration = GetConfiguration();

            var sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }

        public static void ValidateSchema(NHibernate.Cfg.Configuration config)
        {
            var validator = new SchemaValidator(config);
            try
            {
                validator.Validate();
            }
            catch (HibernateException)
            {
                var update = new SchemaUpdate(config);
                update.Execute(false, true);
            }
        }

        public NHibernate.Cfg.Configuration GetConfiguration()
        {
            var assemblies = GetAssemblies();

            if (_databaseProvider == null)
                throw new Exception("Please set the database provider in materialcms.config");

            var iPersistenceConfigurer = _databaseProvider.GetPersistenceConfigurer();
            var autoPersistenceModel = GetAutoPersistenceModel(assemblies);
            ApplyCoreFilters(autoPersistenceModel);

            var config = Fluently.Configure()
                .Database(iPersistenceConfigurer)
                .Mappings(m => m.AutoMappings.Add(autoPersistenceModel))
                .Cache(SetupCache)
                .ExposeConfiguration(AppendListeners)
                .ExposeConfiguration(AppSpecificConfiguration)
                .ExposeConfiguration(c =>
                {
#if DEBUG
                    c.SetProperty(Environment.GenerateStatistics, "true");
#else
                    c.SetProperty(Environment.GenerateStatistics, "false");
#endif
                    c.SetProperty(Environment.Hbm2ddlKeyWords, "auto-quote");
                    c.SetProperty(Environment.BatchSize, "25");
                })
                .BuildConfiguration();


            _databaseProvider.AddProviderSpecificConfiguration(config);

            ValidateSchema(config);

            config.BuildMappings();

            return config;
        }

        private List<Assembly> GetAssemblies()
        {
            var assemblies = TypeHelper.GetAllMaterialCMSAssemblies();
            if (ManuallyAddedAssemblies != null)
                assemblies.AddRange(ManuallyAddedAssemblies);

            var finalAssemblies = new List<Assembly>();

            assemblies.ForEach(assembly =>
            {
                if (finalAssemblies.All(a => a.FullName != assembly.FullName))
                    finalAssemblies.Add(assembly);
            });
            return finalAssemblies;
        }

        private void SetupCache(CacheSettingsBuilder builder)
        {
            if (!CacheEnabled)
                return;

            builder.UseSecondLevelCache()
                .UseQueryCache()
                .QueryCacheFactory<StandardQueryCacheFactory>();
            var providerType = TypeHelper.GetTypeByName(WebConfigurationManager.AppSettings["materialcms-cache-provider"]);
            var cacheInitializers = NHibernateCacheInitializers.Initializers;
            if (providerType != null && cacheInitializers.ContainsKey(providerType))
            {
                var initializer = MaterialCMSKernel.Kernel.Get(cacheInitializers[providerType]) as CacheProviderInitializer;
                if (initializer != null)
                {
                    initializer.Initialize(builder);
                    return;
                }
            }
            builder.ProviderClass<SysCacheProvider>();
        }

        private static void ApplyCoreFilters(AutoPersistenceModel autoPersistenceModel)
        {
            autoPersistenceModel.Add(typeof (NotDeletedFilter));
            autoPersistenceModel.Add(typeof (SiteFilter));
        }

        private static AutoPersistenceModel GetAutoPersistenceModel(List<Assembly> finalAssemblies)
        {
            return AutoMap.Assemblies(new MaterialCMSMappingConfiguration(), finalAssemblies)
                .IgnoreBase<SystemEntity>()
                .IgnoreBase<SiteEntity>()
                .IncludeBase<Document>()
                .IncludeBase<Webpage>()
                .IncludeBase<UserProfileData>()
                .IncludeBase<Widget>()
                .IncludeBase<FormProperty>()
                .IncludeBase<FormPropertyWithOptions>()
                .IncludeBase<BatchJob>()
                .IncludeAppBases()
                .UseOverridesFromAssemblies(finalAssemblies)
                .Conventions.AddFromAssemblyOf<CustomForeignKeyConvention>()
                .IncludeAppConventions();
        }

        private void AppSpecificConfiguration(NHibernate.Cfg.Configuration configuration)
        {
            MaterialCMSApp.AppendAllAppConfiguration(configuration);
        }

        private void AppendListeners(NHibernate.Cfg.Configuration configuration)
        {
            configuration.AppendListeners(ListenerType.PreInsert, new[]
            {
                new SetCoreProperties()
            });
            var softDeleteListener = new SoftDeleteListener();
            configuration.SetListener(ListenerType.Delete, softDeleteListener);
        }
    }
}