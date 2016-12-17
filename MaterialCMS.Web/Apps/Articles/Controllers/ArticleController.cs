using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MaterialCMS.Web.Apps.Articles.ModelBinders;
using MaterialCMS.Web.Apps.Articles.Models;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Services;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Apps.Articles.Controllers
{
    public class ArticleController : MaterialCMSAppUIController<ArticlesApp>
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ActionResult Show(ArticleList page, [IoCModelBinder(typeof(ArticleListModelBinder))]ArticleSearchModel model)
        {
            ViewData["paged-articles"] = _articleService.GetArticles(page, model);
            ViewData["article-search-model"] = model;
            return View(page);
        }
    }
}