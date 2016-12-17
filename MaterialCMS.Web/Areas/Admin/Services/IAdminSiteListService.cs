using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IAdminSiteListService
    {
        List<SelectListItem> GetSiteOptions();
        IList<Site> GetSites();
    }
}