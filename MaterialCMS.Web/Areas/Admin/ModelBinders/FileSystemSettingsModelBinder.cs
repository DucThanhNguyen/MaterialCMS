using System;
using System.Web.Mvc;
using MaterialCMS.Settings;
using MaterialCMS.Website.Binders;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{
    public class FileSystemSettingsModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly FileSystemSettings _fileSystemSettings;

        public FileSystemSettingsModelBinder(IKernel kernel, FileSystemSettings fileSystemSettings) : base(kernel)
        {
            _fileSystemSettings = fileSystemSettings;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                              Type modelType)
        {
            return _fileSystemSettings;
        }
    }
}