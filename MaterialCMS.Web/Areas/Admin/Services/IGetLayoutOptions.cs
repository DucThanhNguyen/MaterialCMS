using System.Collections.Generic;
using System.Web.Mvc;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IGetLayoutOptions
    {
        List<SelectListItem> Get();
    }
}