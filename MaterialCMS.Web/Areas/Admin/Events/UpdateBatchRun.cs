using Microsoft.AspNet.SignalR;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Events;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Hubs;
using MaterialCMS.Web.Areas.Admin.Services.Batching;

namespace MaterialCMS.Web.Areas.Admin.Events
{
    public class UpdateBatchRun : IOnUpdated<BatchRun>
    {
        private readonly IBatchRunUIService _batchRunUIService;

        public UpdateBatchRun(IBatchRunUIService batchRunUIService)
        {
            _batchRunUIService = batchRunUIService;
        }

        public void Execute(OnUpdatedArgs<BatchRun> args)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<BatchProcessingHub>();
            var batchRun = args.Item;
            hubContext.Clients.All.updateRun(batchRun.ToSimpleJson(_batchRunUIService.GetCompletionStatus(batchRun)));
            
        }
    }
}