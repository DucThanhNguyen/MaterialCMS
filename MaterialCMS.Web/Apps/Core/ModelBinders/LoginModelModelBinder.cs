using System.Web.Mvc;
using MaterialCMS.Web.Apps.Core.Models;
using MaterialCMS.Web.Apps.Core.Models.RegisterAndLogin;
using MaterialCMS.Website.Binders;
using NHibernate;
using Ninject;

namespace MaterialCMS.Web.Apps.Core.ModelBinders
{
    public class LoginModelModelBinder : MaterialCMSDefaultModelBinder
    {
        public LoginModelModelBinder(IKernel kernel) : base(kernel)
        {
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var bindModel = base.BindModel(controllerContext, bindingContext);
            if (bindModel is LoginModel)
            {
                if (!string.IsNullOrWhiteSpace((bindModel as LoginModel).Email))
                {
                    (bindModel as LoginModel).Email = (bindModel as LoginModel).Email.Trim();
                }
            }
            return bindModel;
        }
    }
}