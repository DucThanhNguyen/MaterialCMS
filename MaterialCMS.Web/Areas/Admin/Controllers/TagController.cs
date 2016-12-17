using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Models;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class TagController : MaterialCMSAdminController
    {
        private readonly ITagAdminService _tagAdminService;

        public TagController(ITagAdminService tagAdminService)
        {
            _tagAdminService = tagAdminService;
        }

        public JsonResult Search(string term)
        {
            IEnumerable<AutoCompleteResult> result = _tagAdminService.Search(term);

            return Json(result);
        }
    }
}