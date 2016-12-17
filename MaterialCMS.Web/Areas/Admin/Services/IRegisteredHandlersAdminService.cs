using System.Collections.Generic;
using MaterialCMS.Website.Routing;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IRegisteredHandlersAdminService
    {
        List<IMaterialCMSRouteHandler> GetAllHandlers();
    }
}