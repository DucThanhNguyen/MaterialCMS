using System;
using System.Web.Mvc.Async;
using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Settings;
using MaterialCMS.Website.Controllers;
using MaterialCMS.Website.Optimization;

namespace MaterialCMS.Website.Routing
{
    public class HandleStandardMaterialCMSPageExecution : IHandleStandardMaterialCMSPageExecution
    {
        private readonly IControllerManager _controllerManager;
        private readonly SEOSettings _seoSettings;

        public HandleStandardMaterialCMSPageExecution(IControllerManager controllerManager, SEOSettings seoSettings)
        {
            _controllerManager = controllerManager;
            _seoSettings = seoSettings;
        }

        public void Handle(RequestContext context, Webpage webpage, Action<MaterialCMSUIController> beforeExecute)
        {
            var controller = _controllerManager.GetController(context, webpage, context.HttpContext.Request.HttpMethod);

            _controllerManager.SetFormData(webpage, controller, context.HttpContext.Request.Form);

            if (beforeExecute != null)
            {
                var uiController = controller as MaterialCMSUIController;
                if (uiController != null)
                    beforeExecute(uiController);
            }

            if (_seoSettings.EnableHtmlMinification)
                context.HttpContext.Response.Filter = new WhitespaceFilter(context.HttpContext.Response.Filter);
            var asyncController = (controller as IAsyncController);
            asyncController.BeginExecute(context, asyncController.EndExecute, null);
        }
    }
}