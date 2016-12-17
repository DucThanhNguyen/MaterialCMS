using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class FormPropertyWithOptionsOverride : IAutoMappingOverride<FormPropertyWithOptions>
    {
        public void Override(AutoMapping<FormPropertyWithOptions> mapping)
        {
            mapping.HasMany(options => options.Options).KeyColumn("FormPropertyId");
        }
    }
}