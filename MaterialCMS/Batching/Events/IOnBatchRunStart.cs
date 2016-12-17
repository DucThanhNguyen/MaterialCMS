using MaterialCMS.Batching.Entities;
using MaterialCMS.Events;

namespace MaterialCMS.Batching.Events
{
    public interface IOnBatchRunStart : IEvent<BatchRunStartArgs>
    {
         
    }

    public class BatchRunStartArgs
    {
        public BatchRun BatchRun { get; set; }
    }
}