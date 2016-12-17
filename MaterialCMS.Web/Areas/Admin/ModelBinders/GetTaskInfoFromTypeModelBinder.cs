using System;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class GetTaskInfoFromTypeModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly ITaskAdminService _taskAdminService;

        public GetTaskInfoFromTypeModelBinder(ITaskAdminService taskAdminService, IKernel kernel) : base(kernel)
        {
            _taskAdminService = taskAdminService;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var valueFromContext = GetValueFromContext(controllerContext, "type");
            var taskInfo = _taskAdminService.GetTaskUpdateData(valueFromContext);
            return taskInfo;
        }
    }
}