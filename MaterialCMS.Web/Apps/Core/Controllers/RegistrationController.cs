using System.Threading.Tasks;
using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Services.Resources;
using MaterialCMS.Web.Apps.Core.Models.RegisterAndLogin;
using MaterialCMS.Web.Apps.Core.Pages;
using MaterialCMS.Web.Apps.Core.Services;
using MaterialCMS.Website;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Apps.Core.Controllers
{
    public class RegistrationController : MaterialCMSAppUIController<CoreApp>
    {
        private readonly IRegistrationService _registrationService;
        private readonly IStringResourceProvider _stringResourceProvider;

        public RegistrationController(IRegistrationService registrationService, IStringResourceProvider stringResourceProvider)
        {
            _registrationService = registrationService;
            _stringResourceProvider = stringResourceProvider;
        }

        public ActionResult Show(RegisterPage page)
        {
            if (CurrentRequestData.CurrentUser != null && !CurrentRequestData.CurrentUserIsAdmin)
                return Redirect("~/");
            return View(page);
        }

        [HttpGet]
        public ViewResult RegistrationDetails(RegisterModel model, string returnUrl = null)
        {
            ViewBag.Message = TempData["already-logged-in"];
            ModelState.Clear();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ActionName("RegistrationDetails")]
        public async Task<RedirectResult> RegistrationDetails_POST(RegisterModel model)
        {
            if (CurrentRequestData.CurrentUser != null)
            {
                TempData["already-logged-in"] = _stringResourceProvider.GetValue("Register Already Logged in", "You are already logged in. Please logout to create a new account.");
                return Redirect(UniquePageHelper.GetUrl<RegisterPage>());
            }

            if (model != null && ModelState.IsValid && _registrationService.CheckEmailIsNotRegistered(model.Email))
            {
                await _registrationService.RegisterUser(model);

                return !string.IsNullOrEmpty(model.ReturnUrl)
                    ? Redirect("~/" + model.ReturnUrl)
                    : Redirect("~/");
            }
            return Redirect(UniquePageHelper.GetUrl<RegisterPage>());
        }

        public JsonResult CheckEmailIsNotRegistered(string email)
        {
            return Json(_registrationService.CheckEmailIsNotRegistered(email), JsonRequestBehavior.AllowGet);
        }
    }
}