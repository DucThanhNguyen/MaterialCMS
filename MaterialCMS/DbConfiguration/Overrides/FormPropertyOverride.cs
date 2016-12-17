using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class FormPropertyOverride : IAutoMappingOverride<FormProperty>
    {
        public void Override(AutoMapping<FormProperty> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("PropertyType");
        }
    }
}