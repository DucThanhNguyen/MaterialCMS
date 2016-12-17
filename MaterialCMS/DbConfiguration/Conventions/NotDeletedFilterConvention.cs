using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using MaterialCMS.DbConfiguration.Filters;

namespace MaterialCMS.DbConfiguration.Conventions
{
    public class NotDeletedFilterConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.ApplyFilter<NotDeletedFilter>();
        }
    }
}