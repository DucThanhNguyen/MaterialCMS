using Microsoft.AspNet.SignalR;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Batching.Services;
using MaterialCMS.Events;
using MaterialCMS.Web.Areas.Admin.Hubs;

namespace MaterialCMS.Web.Areas.Admin.Events
{
    public class RefreshUIOnBatchRunComplete : IOnUpdated<BatchRun>
    {
        public void Execute(OnUpdatedArgs<BatchRun> args)
        {
            var batchRun = args.Item;
            var previous = args.Original;
            if (batchRun.Status == BatchRunStatus.Complete && previous.Status != BatchRunStatus.Complete)
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<BatchProcessingHub>();
                hubContext.Clients.All.refreshBatchRunUI(batchRun.Id);
                
            }
        }
    }
}