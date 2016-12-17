using System;
using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Services.Resources;
using Ninject;

namespace MaterialCMS.Website
{
    public class MaterialCMSMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IKernel _kernel;

        public MaterialCMSMetadataProvider(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            var metadataForProperty = base.GetMetadataForProperty(modelAccessor, containerType, propertyName);
            if (CurrentRequestData.DatabaseIsInstalled)
            {
                var key = string.Format("{0}.{1}", containerType.FullName, propertyName);
                var displayName = _kernel.Get<IStringResourceProvider>()
                    .GetValue(key,
                        (metadataForProperty.DisplayName ?? metadataForProperty.PropertyName ?? string.Empty).BreakUpString());
                if (!string.IsNullOrWhiteSpace(displayName))
                    metadataForProperty.DisplayName = displayName;
            }
            return metadataForProperty;
        }
    }
}