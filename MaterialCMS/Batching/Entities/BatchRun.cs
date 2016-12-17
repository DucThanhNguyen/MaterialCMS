using System.Collections.Generic;
using MaterialCMS.Entities;

namespace MaterialCMS.Batching.Entities
{
    public class BatchRun : SiteEntity
    {
        public virtual Batch Batch { get; set; }
        public virtual BatchRunStatus Status { get; set; }
        public virtual IList<BatchRunResult> BatchRunResults { get; set; }
    }
}