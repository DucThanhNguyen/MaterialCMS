using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Tasks;

namespace MaterialCMS.DbConfiguration.Overrides
{
    public class QueuedTaskOverride : IAutoMappingOverride<QueuedTask>
    {
        public void Override(AutoMapping<QueuedTask> mapping)
        {
            mapping.Map(task => task.Data).MakeVarCharMax();
        }
    }
}