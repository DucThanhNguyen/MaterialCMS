using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace MaterialCMS.DbConfiguration.Conventions
{
    public class RootGuidConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.Name == "Guid" && instance.Property.PropertyType == typeof (Guid))
            {
                instance.Access.ReadOnlyPropertyThroughCamelCaseField(CamelCasePrefix.Underscore);
                instance.Index(string.Format("IX_{0}_{1}", instance.EntityType.Name, instance.Property.Name));
            }
        }
    }
}