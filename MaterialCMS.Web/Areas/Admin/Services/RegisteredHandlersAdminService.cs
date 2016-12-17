using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Website.Routing;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class RegisteredHandlersAdminService : IRegisteredHandlersAdminService
    {
        private readonly IEnumerable<IMaterialCMSRouteHandler> _handlers;

        public RegisteredHandlersAdminService(IEnumerable<IMaterialCMSRouteHandler> handlers)
        {
            _handlers = handlers;
        }

        public List<IMaterialCMSRouteHandler> GetAllHandlers()
        {
            return _handlers.OrderByDescending(handler => handler.Priority).ToList();
        }
    }
}