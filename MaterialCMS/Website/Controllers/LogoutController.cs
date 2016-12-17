using System.Web.Mvc;
using MaterialCMS.Services;

namespace MaterialCMS.Website.Controllers
{
    public class LogoutController : MaterialCMSUIController
    {
        private readonly IAuthorisationService _authorisationService;

        public LogoutController(IAuthorisationService authorisationService)
        {
            _authorisationService = authorisationService;
        }

        public RedirectResult Logout()
        {
            _authorisationService.Logout();
            return Redirect("~");
        }
    }
}