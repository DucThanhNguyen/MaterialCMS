using System.ServiceModel.Syndication;
using MaterialCMS.Web.Apps.Articles.Pages;

namespace MaterialCMS.Web.Apps.Articles.Services
{
    public interface IArticlesRssService
    {
        SyndicationFeed GetSyndicationFeed(ArticleList page);
    }
}