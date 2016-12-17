using System.Web.Mvc;
using MaterialCMS.Web.Apps.Core.ModelBinders;
using MaterialCMS.Web.Apps.Core.Models.Search;
using MaterialCMS.Web.Apps.Core.Pages;
using MaterialCMS.Web.Apps.Core.Services.Search;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Apps.Core.Controllers
{
    public class SearchPageController : MaterialCMSAppUIController<CoreApp>
    {
        private readonly IWebpageSearchService _webpageSearchService;

        public SearchPageController(IWebpageSearchService webpageSearchService)
        {
            _webpageSearchService = webpageSearchService;
        }

        public ActionResult Show(SearchPage page, [IoCModelBinder(typeof(WebpageSearchQueryModelBinder))]WebpageSearchQuery model)
        {
            ViewData["webpageSearchQueryModel"] = model;

            if (string.IsNullOrWhiteSpace(model.Term))
                return View(page);

            ViewData["searchResults"] = _webpageSearchService.Search(model);
            return View(page);
        }
    }
}
