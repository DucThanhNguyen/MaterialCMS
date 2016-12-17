using System.Web.Mvc;
using MaterialCMS.Entities.People;
using MaterialCMS.Services;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Apps.Articles.Areas.Admin.Controllers
{
    public class ArticleController : MaterialCMSAppAdminController<ArticlesApp>
    {
        private readonly IBelongToUserLookupService _belongToUserLookupService;

        public ArticleController(IBelongToUserLookupService belongToUserLookupService)
        {
            _belongToUserLookupService = belongToUserLookupService;
        }

        [ChildActionOnly]
        public PartialViewResult ForUser(User user)
        {
            var articles = _belongToUserLookupService.GetAll<Article>(user);
            return PartialView(articles);
        }
    }
}