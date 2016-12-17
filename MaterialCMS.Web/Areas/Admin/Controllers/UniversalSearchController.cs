using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class UniversalSearchController : MaterialCMSAdminController
    {
        private readonly IUniversalSearchIndexSearcher _searchIndexSearcher;

        public UniversalSearchController(IUniversalSearchIndexSearcher searchIndexSearcher)
        {
            _searchIndexSearcher = searchIndexSearcher;
        }

        [HttpGet]
        public JsonResult QuickSearch(QuickSearchParams searchParams)
        {
            return Json(_searchIndexSearcher.QuickSearch(searchParams), JsonRequestBehavior.AllowGet);
        }
    }
}