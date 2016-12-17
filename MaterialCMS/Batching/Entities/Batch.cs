using System.Collections.Generic;
using MaterialCMS.Entities;

namespace MaterialCMS.Batching.Entities
{
    public class Batch : SiteEntity
    {
        public virtual IList<BatchJob> BatchJobs { get; set; }
        public virtual IList<BatchRun> BatchRuns { get; set; }
    }
}