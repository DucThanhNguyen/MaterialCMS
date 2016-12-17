using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaterialCMS.Paging;
using MaterialCMS.Web.Apps.Articles.Models;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Widgets;
using MaterialCMS.Website;
using NHibernate.Transform;

namespace MaterialCMS.Web.Apps.Articles.Services
{
    public interface IArticleService
    {
        IPagedList<Article> GetArticles(ArticleList page, ArticleSearchModel model);
        List<ArchiveModel> GetMonthsAndYears(ArticleList articleList);
    }
}
