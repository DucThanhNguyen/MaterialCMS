using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Widgets;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;
using NHibernate;

namespace MaterialCMS.Web.Apps.Articles.Areas.Admin.Services
{
    public class GetLatestArticlesAdminViewData : BaseAssignWidgetAdminViewData<LatestXArticles>
    {
        private readonly ISession _session;

        public GetLatestArticlesAdminViewData(ISession session)
        {
            _session = session;
        }

        public override void AssignViewData(LatestXArticles widget, ViewDataDictionary viewData)
        {
            viewData["newsList"] = _session.QueryOver<ArticleList>()
                .Where(article => article.PublishOn != null && article.PublishOn <= CurrentRequestData.Now)
                .Cacheable()
                .List()
                .BuildSelectItemList(item => item.Name,
                    item => item.Id.ToString(),
                    emptyItemText: "Please select news list");
        }
    }
}