using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IPageDefaultsAdminService
    {
        List<PageDefaultsInfo> GetAll();
        List<SelectListItem> GetUrlGeneratorOptions(Type type);
        List<SelectListItem> GetLayoutOptions();
        DefaultsInfo GetInfo(Type type);
        void SetDefaults(DefaultsInfo info);
    }
}