using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Models.WebpageEdit;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IGetWebpageEditTabsService
    {
        List<WebpageTabBase> GetEditTabs(Webpage page);
    }
}