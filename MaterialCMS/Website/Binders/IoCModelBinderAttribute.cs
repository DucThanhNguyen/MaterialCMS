using System;
using System.Web.Mvc;

namespace MaterialCMS.Website.Binders
{
    public class IoCModelBinderAttribute : CustomModelBinderAttribute
    {
        public IoCModelBinderAttribute(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (!typeof(MaterialCMSDefaultModelBinder).IsAssignableFrom(type))
            {
                var message = string.Format("{0} is not a valid model binder", type.AssemblyQualifiedName);
                throw new ArgumentException(message, "type");
            }

            BinderType = type;
        }

        private Type BinderType { get; set; }

        public override IModelBinder GetBinder()
        {
            try
            {
                return MaterialCMSApplication.Get(BinderType) as IModelBinder;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    string.Format("Error instantiating model binder of type {0}", BinderType.AssemblyQualifiedName), ex);
            }
        }
    }
}