using MaterialCMS.Batching.Entities;
using MaterialCMS.Web.Areas.Admin.Services.Batching;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Areas.Admin.Helpers
{
    public static class BatchExtensions
    {
        public static int GetItemCount(this Batch batch)
        {
            return MaterialCMSApplication.Get<IGetBatchItemCount>().Get(batch);
        }

        public static BatchStatus GetStatus(this Batch batch)
        {
            return MaterialCMSApplication.Get<IGetBatchStatus>().Get(batch);
        }
    }
}