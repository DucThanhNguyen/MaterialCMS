using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using MaterialCMS.DbConfiguration.Filters;
using MaterialCMS.Entities;

namespace MaterialCMS.DbConfiguration.Conventions
{
    public class SiteFilterConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            if (instance.EntityType.IsSubclassOf(typeof (SiteEntity)))
            {
                instance.ApplyFilter<SiteFilter>();
            }
        }
    }
}