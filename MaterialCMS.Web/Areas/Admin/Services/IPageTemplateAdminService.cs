using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IPageTemplateAdminService
    {
        IPagedList<PageTemplate> Search(PageTemplateSearchQuery query);
        void Add(PageTemplate template);
        void Update(PageTemplate template);

        List<SelectListItem> GetPageTypeOptions();
        List<SelectListItem> GetLayoutOptions();
        List<SelectListItem> GetUrlGeneratorOptions(Type type);
    }
}