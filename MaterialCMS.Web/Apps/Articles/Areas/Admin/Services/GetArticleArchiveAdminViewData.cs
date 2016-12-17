using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Widgets;
using MaterialCMS.Web.Areas.Admin.Services;
using NHibernate;

namespace MaterialCMS.Web.Apps.Articles.Areas.Admin.Services
{
    public class GetArticleArchiveAdminViewData:BaseAssignWidgetAdminViewData<ArticleArchive>
    {
        private readonly ISession _session;

        public GetArticleArchiveAdminViewData(ISession session)
        {
            _session = session;
        }

        public override void AssignViewData(ArticleArchive widget, ViewDataDictionary viewData)
        {
            viewData["ArticleLists"] = _session.QueryOver<ArticleList>()
                .OrderBy(list => list.Name)
                .Asc.Cacheable()
                .List()
                .BuildSelectItemList(category => category.Name,
                    category => category.Id.ToString(),
                    emptyItemText: "Select an article list...");
        }
    }
}