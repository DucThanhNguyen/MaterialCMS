using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MaterialCMS.Batching.Entities;
using MaterialCMS.DbConfiguration;

namespace MaterialCMS.Batching.DbConfiguration
{
    public class BatchJobOverride : IAutoMappingOverride<BatchJob>
    {
        public void Override(AutoMapping<BatchJob> mapping)
        {
            mapping.Map(job => job.Data).MakeVarCharMax();
        }
    }
}