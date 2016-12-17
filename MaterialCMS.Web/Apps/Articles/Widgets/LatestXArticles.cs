using MaterialCMS.Entities.Widget;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Articles.Widgets
{
    [OutputCacheable]
    public class LatestXArticles : Widget
    {
        public virtual int NumberOfArticles { get; set; }
        public virtual ArticleList RelatedNewsList { get; set; }
    }
}