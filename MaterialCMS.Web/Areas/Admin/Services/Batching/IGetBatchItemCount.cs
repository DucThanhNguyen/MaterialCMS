using MaterialCMS.Batching.Entities;

namespace MaterialCMS.Web.Areas.Admin.Services.Batching
{
    public interface IGetBatchItemCount
    {
        int Get(Batch batch);
    }
}