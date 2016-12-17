using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Messaging;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class QueuedMessageAttachmentOverride : IAutoMappingOverride<QueuedMessageAttachment>
    {
        public void Override(AutoMapping<QueuedMessageAttachment> mapping)
        {
            mapping.Map(entry => entry.Data).Length(9999);
        }
    }
}