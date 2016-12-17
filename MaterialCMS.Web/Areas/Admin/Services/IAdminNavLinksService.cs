using System.Collections.Generic;
using MaterialCMS.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IAdminNavLinksService
    {
        IEnumerable<IAdminMenuItem> GetNavLinks();
    }
}