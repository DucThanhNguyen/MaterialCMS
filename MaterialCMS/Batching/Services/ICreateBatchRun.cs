using System.Linq;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface ICreateBatchRun
    {
        BatchRun Create(Batch batch);
    }
}