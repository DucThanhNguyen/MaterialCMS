using System.Threading.Tasks;
using MaterialCMS.Services;

namespace MaterialCMS.Batching.CoreJobs
{
    public class RebuildLuceneIndexExecutor : BaseBatchJobExecutor<RebuildLuceneIndex>
    {
        private readonly IIndexService _indexService;

        public RebuildLuceneIndexExecutor(ISetBatchJobExecutionStatus setBatchJobJobExecutionStatus,
            IIndexService indexService)
            : base(setBatchJobJobExecutionStatus)
        {
            _indexService = indexService;
        }

        protected override BatchJobExecutionResult OnExecute(RebuildLuceneIndex batchJob)
        {
            _indexService.Reindex(batchJob.IndexName);
            return BatchJobExecutionResult.Success();
        }

        protected override Task<BatchJobExecutionResult> OnExecuteAsync(RebuildLuceneIndex batchJob)
        {
            throw new System.NotImplementedException();
        }
    }
}