using FluentNHibernate.Cfg.Db;

namespace MaterialCMS.DbConfiguration
{
    public interface IDatabaseProvider
    {
        string Type { get; }
        IPersistenceConfigurer GetPersistenceConfigurer();
        void AddProviderSpecificConfiguration(NHibernate.Cfg.Configuration config);
    }
}