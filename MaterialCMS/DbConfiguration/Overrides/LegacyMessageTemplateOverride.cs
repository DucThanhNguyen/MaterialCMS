using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Messaging;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class LegacyMessageTemplateOverride : IAutoMappingOverride<LegacyMessageTemplate>
    {
        public void Override(AutoMapping<LegacyMessageTemplate> mapping)
        {
            mapping.Table("MessageTemplate");
        }
    }
}