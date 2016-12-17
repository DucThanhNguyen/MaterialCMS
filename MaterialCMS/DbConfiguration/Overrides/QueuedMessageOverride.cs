using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.DbConfiguration.Types;
using MaterialCMS.Entities.Messaging;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class QueuedMessageOverride : IAutoMappingOverride<QueuedMessage>
    {
        public void Override(AutoMapping<QueuedMessage> mapping)
        {
            mapping.Map(message => message.Body).CustomType<VarcharMax>().Length(4001);
            mapping.HasMany(message => message.QueuedMessageAttachments).Cascade.Delete().KeyColumn("QueuedMessageId");
        }
    }
}