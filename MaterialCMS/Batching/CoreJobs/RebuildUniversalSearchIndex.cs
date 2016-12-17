using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.CoreJobs
{
    public class RebuildUniversalSearchIndex : BatchJob
    {
        public override string Name
        {
            get { return "Rebuild Universal Index"; }
        }
    }
}