using System.Threading.Tasks;
using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Batching.Services
{
    public interface ISynchronousBatchRunExecution
    {
        Task Execute(BatchRun run);
    }
}