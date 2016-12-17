using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class FormListOptionOverride : IAutoMappingOverride<FormListOption>
    {
        public void Override(AutoMapping<FormListOption> mapping)
        {
            mapping.References(option => option.FormProperty).Column("FormPropertyId");
        }
    }
}