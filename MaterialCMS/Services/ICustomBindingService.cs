using System.Web.Mvc;
using MaterialCMS.Entities;

namespace MaterialCMS.Services
{
    public interface ICustomBindingService
    {
        void ApplyCustomBinding<T>(T entity, ControllerContext controllerContext) where T : SystemEntity;
    }
}