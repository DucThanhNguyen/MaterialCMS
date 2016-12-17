using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IGetUrlGeneratorOptions
    {
        List<SelectListItem> Get(Type type, Type currentGeneratorType = null);
    }
}