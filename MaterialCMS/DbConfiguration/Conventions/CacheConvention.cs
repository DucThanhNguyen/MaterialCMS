using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using MaterialCMS.Entities;
using MaterialCMS.Entities.Documents;

namespace MaterialCMS.DbConfiguration.Conventions
{
    public class CacheConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Cache.ReadWrite();
        }
    }
}