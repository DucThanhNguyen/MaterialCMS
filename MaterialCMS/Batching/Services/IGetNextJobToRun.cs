using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface IGetNextJobToRun
    {
        NextJobToRunResult Get(BatchRun batchRun);
    }

    public struct NextJobToRunResult
    {
        public bool Paused { get; set; }
        public bool Complete { get; set; }
        public BatchRunResult Result { get; set; }
    }
}