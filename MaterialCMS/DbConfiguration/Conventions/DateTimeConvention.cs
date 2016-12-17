using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Entities;
using MaterialCMS.Helpers;

namespace MaterialCMS.DbConfiguration.Conventions
{
    public class DateTimeConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (typeof(SiteEntity).IsAssignableFrom(instance.EntityType))
            {
                if (instance.Property.PropertyType == typeof(DateTime))
                    instance.CustomType<DateTimeData>();
                else if (instance.Property.PropertyType == typeof(DateTime?))
                    instance.CustomType<NullableDateTimeData>();
            }
            else if (typeof(SystemEntity).IsAssignableFrom(instance.EntityType))
            {
                if (instance.Property.PropertyType == typeof(DateTime))
                    instance.CustomType<LocalDateTimeData>();
                else if (instance.Property.PropertyType == typeof(DateTime?))
                    instance.CustomType<LocalNullableDateTimeData>();

            }
        }
    }
}