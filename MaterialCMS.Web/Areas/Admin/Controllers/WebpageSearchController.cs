using System.Web.Mvc;
using System.Web.UI;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class WebpageSearchController : MaterialCMSAdminController
    {
        private readonly IWebpageAdminSearchService _webpageAdminSearchService;

        public WebpageSearchController(IWebpageAdminSearchService webpageAdminSearchService)
        {
            _webpageAdminSearchService = webpageAdminSearchService;
        }

        public ViewResult Search(WebpageSearchQuery searchQuery)
        {
            return View(searchQuery);
        }

        public PartialViewResult Results(WebpageSearchQuery searchQuery)
        {
            ViewData["results"] = _webpageAdminSearchService.Search(searchQuery);
            return PartialView(searchQuery);
        }
    }
}