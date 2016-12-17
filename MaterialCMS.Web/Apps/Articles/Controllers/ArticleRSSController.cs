using MaterialCMS.Web.Apps.Articles.ActionResults;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Apps.Articles.Controllers
{
    public class ArticleRSSController : MaterialCMSAppUIController<ArticlesApp>
    {
        private readonly IArticlesRssService _articlesRssService;

        public ArticleRSSController(IArticlesRssService articlesRssService)
        {
            _articlesRssService = articlesRssService;
        }

        public RssActionResult Show(ArticleList page)
        {
            var feed = _articlesRssService.GetSyndicationFeed(page);
            return new RssActionResult { Feed = feed };
        }
    }
}