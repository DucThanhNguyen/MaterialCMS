using Microsoft.AspNet.SignalR;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Events;
using MaterialCMS.Web.Areas.Admin.Hubs;

namespace MaterialCMS.Web.Areas.Admin.Events
{
    public class UpdateBatchJob : IOnUpdated<BatchJob>
    {
        public void Execute(OnUpdatedArgs<BatchJob> args)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<BatchProcessingHub>();
            hubContext.Clients.All.updateJob(args.Item.Id);
        }
    }
    
}