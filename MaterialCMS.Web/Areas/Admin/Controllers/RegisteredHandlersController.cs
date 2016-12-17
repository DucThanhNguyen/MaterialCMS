using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class RegisteredHandlersController : MaterialCMSAdminController
    {
        private readonly IRegisteredHandlersAdminService _registeredHandlersAdminService;

        public RegisteredHandlersController(IRegisteredHandlersAdminService registeredHandlersAdminService)
        {
            _registeredHandlersAdminService = registeredHandlersAdminService;
        }

        public ViewResult Index()
        {
            return View(_registeredHandlersAdminService.GetAllHandlers());
        }
    }
}