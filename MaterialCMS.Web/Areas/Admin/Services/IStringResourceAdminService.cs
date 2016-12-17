using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Entities.Resources;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IStringResourceAdminService
    {
        IPagedList<StringResource> Search(StringResourceSearchQuery searchQuery);
        void Add(StringResource resource);
        void Update(StringResource resource);
        void Delete(StringResource resource);
        List<SelectListItem> GetLanguageOptions(string key, Site site);
        List<SelectListItem> SearchLanguageOptions();
        StringResource GetNewResource(string key, Site site);
        List<SelectListItem> ChooseSiteOptions(ChooseSiteParams chooseSiteParams);
        List<SelectListItem> SearchSiteOptions();
    }
}