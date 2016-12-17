using MaterialCMS.Batching.Entities;
using MaterialCMS.Entities;
using MaterialCMS.Helpers;
using NHibernate;

namespace MaterialCMS.Batching
{
    public class SetBatchJobExecutionStatus : ISetBatchJobExecutionStatus
    {
        private readonly ISession _session;

        public SetBatchJobExecutionStatus(ISession session)
        {
            _session = session;
        }

        public void Starting<T>(T entity) where T : SystemEntity, IHaveJobExecutionStatus
        {
            _session.Transact(session =>
            {
                entity.Status = JobExecutionStatus.Executing;
                session.Update(entity);
            });
        }

        public void Complete<T>(T entity, BatchJobExecutionResult result) where T : SystemEntity, IHaveJobExecutionStatus
        {
            _session.Transact(session =>
            {
                entity.Status = result.Successful ? JobExecutionStatus.Succeeded : JobExecutionStatus.Failed;
                session.Update(entity);
            });

        }
    }
}