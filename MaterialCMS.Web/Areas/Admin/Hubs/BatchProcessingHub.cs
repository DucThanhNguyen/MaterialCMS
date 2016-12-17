using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MaterialCMS.Web.Areas.Admin.Hubs
{
    [MaterialCMSAuthorize]
    [HubName("batch")]
    public class BatchProcessingHub : Hub
    {
        
    }
}