using System;
using System.ComponentModel;
using System.Web.Mvc;
using MaterialCMS.Entities;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Controllers;
using NHibernate;
using NHibernate.Proxy;
using Ninject;

namespace MaterialCMS.Website.Binders
{
    public class MaterialCMSDefaultModelBinder : DefaultModelBinder
    {
        protected readonly IKernel Kernel;

        public MaterialCMSDefaultModelBinder(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected ISession Session
        {
            get { return Get<ISession>(); }
        }

        protected T Get<T>()
        {
            return Kernel.Get<T>();
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.Controller is MaterialCMSAdminController &&
                typeof(SystemEntity).IsAssignableFrom(bindingContext.ModelType) &&
                (CreateModel(controllerContext, bindingContext, bindingContext.ModelType) == null ||
                 ShouldReturnNull(controllerContext, bindingContext)))
                return null;

            object bindModel = base.BindModel(controllerContext, bindingContext);
            if (bindModel is SiteEntity)
            {
                object model = bindModel;
                bindingContext.ModelState.Clear();
                bindingContext.ModelMetadata =
                    ModelMetadataProviders.Current.GetMetadataForType(
                        () => CreateModel(controllerContext, bindingContext, model.GetType()), bindModel.GetType());
                bindingContext.ModelMetadata.Model = bindModel;
                bindModel = base.BindModel(controllerContext, bindingContext);
                var baseEntity = bindModel as SiteEntity;
                if (baseEntity != null)
                {
                    baseEntity.ApplyCustomBinding(controllerContext);
                }
            }
            return bindModel;
        }

        protected virtual bool ShouldReturnNull(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return false;
        }

        protected override object GetPropertyValue(ControllerContext controllerContext,
                                                   ModelBindingContext bindingContext,
                                                   PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.PropertyType.IsSubclassOf(typeof(SystemEntity)))
            {
                string id = controllerContext.HttpContext.Request[bindingContext.ModelName + ".Id"];
                int idVal;
                return int.TryParse(id, out idVal)
                           ? Session.Get(propertyDescriptor.PropertyType,
                                         idVal)
                           : null;
            }

            object value = base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
            return value;
        }

        protected static string GetValueFromContext(ControllerContext controllerContext, string request)
        {
            return controllerContext.GetValueFromRequest(request);
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                              Type modelType)
        {
            object modelFromSession = GetModelFromSession(controllerContext, bindingContext.ModelName, modelType);
            if (modelFromSession != null)
                return modelFromSession;
            if (modelType == typeof(Webpage))
                return null;
            object model = base.CreateModel(controllerContext, bindingContext, modelType);

            return model;
        }

        public object GetModelFromSession(ControllerContext controllerContext, string modelName, Type modelType)
        {
            if (typeof(SystemEntity).IsAssignableFrom(modelType))
            {
                string subItem = string.Format("{0}.Id", modelName);

                string id =
                    Convert.ToString(controllerContext.RouteData.Values[subItem] ??
                                     controllerContext.HttpContext.Request[subItem]);

                int intId;
                if (int.TryParse(id, out intId))
                {
                    object obj = Unproxy(Session.Get(modelType, intId));
                    return obj ?? Activator.CreateInstance(modelType);
                }

                const string baseId = "Id";
                id = Convert.ToString(controllerContext.RouteData.Values[baseId] ??
                                      controllerContext.HttpContext.Request[baseId]);

                if (int.TryParse(id, out intId))
                {
                    object obj = Unproxy(Session.Get(modelType, intId));
                    return obj ?? Activator.CreateInstance(modelType);
                }
            }
            return null;
        }

        private object Unproxy(object obj)
        {
            var proxy = obj as INHibernateProxy;
            if (proxy != null)
            {
                return proxy.HibernateLazyInitializer.GetImplementation();
            }

            return obj;
        }
    }
}