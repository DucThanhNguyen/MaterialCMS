using System.Web.Mvc;
using MaterialCMS.Entities.People;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class AddUserModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly IPasswordManagementService _passwordManagementService;

        public AddUserModelBinder(IKernel kernel, IPasswordManagementService passwordManagementService) : base(kernel)
        {
            _passwordManagementService = passwordManagementService;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var user = base.BindModel(controllerContext, bindingContext) as User;

            _passwordManagementService.SetPassword(user,
                                                   controllerContext.GetValueFromRequest("Password"),
                                                   controllerContext.GetValueFromRequest("ConfirmPassword"));

            return user;
        }
    }
}