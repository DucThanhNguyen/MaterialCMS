using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Entities.Notifications;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class NotificationOverride : IAutoMappingOverride<Notification>
    {
        public void Override(AutoMapping<Notification> mapping)
        {
            mapping.Map(notification => notification.Message).MakeVarCharMax();
        }
    }
}