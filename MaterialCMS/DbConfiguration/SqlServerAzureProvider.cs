using System.ComponentModel;
using FluentNHibernate.Cfg.Db;
using MaterialCMS.Settings;
using NHibernate.SqlAzure;

namespace MaterialCMS.DbConfiguration
{
    [Description("Use SQL with Azure.")]
    public class SqlServerAzureProvider : IDatabaseProvider
    {
        private readonly DatabaseSettings _databaseSettings;

        public SqlServerAzureProvider(DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        public IPersistenceConfigurer GetPersistenceConfigurer()
        {

            return
                MsSqlConfiguration.MsSql2008.ConnectionString(x => x.Is(_databaseSettings.ConnectionString))
                    .Driver<SqlAzureClientDriver>();
        }

        public void AddProviderSpecificConfiguration(NHibernate.Cfg.Configuration config)
        {
            SqlServerGuidHelper.SetGuidToUniqueWithDefaultValue(config);
        }

        public string Type
        {
            get { return GetType().FullName; }
        }
    }
}