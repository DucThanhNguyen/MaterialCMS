using System.Web.Mvc;
using MaterialCMS.Entities;
using MaterialCMS.Services;
using MaterialCMS.Website;

namespace MaterialCMS.Helpers
{
    public static class CustomBindingExtensions
    {
        public static void ApplyCustomBinding<T>(this T entity, ControllerContext context) where T : SystemEntity
        {
            MaterialCMSApplication.Get<ICustomBindingService>().ApplyCustomBinding(entity, context);
        }
    }
}