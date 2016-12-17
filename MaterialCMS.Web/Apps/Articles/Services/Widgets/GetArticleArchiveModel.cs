using MaterialCMS.Services.Widgets;
using MaterialCMS.Web.Apps.Articles.Models;
using MaterialCMS.Web.Apps.Articles.Widgets;

namespace MaterialCMS.Web.Apps.Articles.Services.Widgets
{
    public class GetArticleArchiveModel : GetWidgetModelBase<ArticleArchive>
    {
        private readonly IArticleService _articleService;

        public GetArticleArchiveModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public override object GetModel(ArticleArchive widget)
        {
            var model = new ArticleArchiveModel
            {
                ArticleYearsAndMonths = _articleService.GetMonthsAndYears(widget.ArticleList),
                ArticleList = widget.ArticleList,
                ArticleArchive = widget
            };

            return model;
        }
    }
}