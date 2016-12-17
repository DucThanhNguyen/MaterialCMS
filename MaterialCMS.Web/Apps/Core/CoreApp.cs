using MaterialCMS.Apps;
using Ninject;

namespace MaterialCMS.Web.Apps.Core
{
    public class CoreApp : MaterialCMSApp
    {
        public override string AppName
        {
            get { return "Core"; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        protected override void RegisterServices(IKernel kernel)
        {
        }

        protected override void RegisterApp(MaterialCMSAppRegistrationContext context)
        {
            context.MapRoute("External Login", "external-login", new {controller = "ExternalLogin", action = "Login"});
            context.MapRoute("External Login Callback", "external-login/callback",
                new {controller = "ExternalLogin", action = "Callback"});

            context.MapRoute("User Registration", "Registration/RegistrationDetails",
                new {controller = "Registration", action = "RegistrationDetails"});
            context.MapRoute("User Registration - check email", "Registration/CheckEmailIsNotRegistered",
                new {controller = "Registration", action = "CheckEmailIsNotRegistered"});

            context.MapRoute("UserAccountController - account details", "UserAccount/UserAccountDetails",
                new {controller = "UserAccount", action = "UserAccountDetails"});
            context.MapRoute("UserAccountController - check email isn't already registered", "UserAccount/IsUniqueEmail",
                new {controller = "UserAccount", action = "IsUniqueEmail"});

            context.MapRoute("UserAccountController - change password", "UserAccount/ChangePassword",
                new {controller = "UserAccount", action = "ChangePassword"});
        }
    }
}