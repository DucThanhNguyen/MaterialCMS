using System.Collections.Generic;
using System.Web.Mvc;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IGetUserCultureOptions
    {
        List<SelectListItem> Get();
    }
}