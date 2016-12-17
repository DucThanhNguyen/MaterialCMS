using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Helpers;
using MaterialCMS.Models;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class AdminNavLinksService : IAdminNavLinksService
    {
        private readonly IKernel _kernel;

        public AdminNavLinksService(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IEnumerable<IAdminMenuItem> GetNavLinks()
        {
            return TypeHelper.GetAllConcreteTypesAssignableFrom<IAdminMenuItem>()
                .Where(type => type != typeof (ChildMenuItem))
                .Select(type => _kernel.Get(type)).Cast<IAdminMenuItem>()
                .OrderBy(item => item.DisplayOrder);
        }
    }
}