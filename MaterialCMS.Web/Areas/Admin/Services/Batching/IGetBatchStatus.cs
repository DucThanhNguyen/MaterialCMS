using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Web.Areas.Admin.Services.Batching
{
    public interface IGetBatchStatus
    {
        BatchStatus Get(Batch batch);
    }
}