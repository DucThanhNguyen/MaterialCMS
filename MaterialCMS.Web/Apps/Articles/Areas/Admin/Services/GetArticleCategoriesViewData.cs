using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Widgets;
using MaterialCMS.Web.Areas.Admin.Services;
using NHibernate;

namespace MaterialCMS.Web.Apps.Articles.Areas.Admin.Services
{
    public class GetArticleCategoriesViewData : BaseAssignWidgetAdminViewData<ArticleCategories>
    {
        private readonly ISession _session;

        public GetArticleCategoriesViewData(ISession session)
        {
            _session = session;
        }

        public override void AssignViewData(ArticleCategories widget, ViewDataDictionary viewData)
        {
            viewData["ArticleLists"] = _session.QueryOver<ArticleList>()
                .OrderBy(list => list.Name)
                .Desc.Cacheable()
                .List()
                .BuildSelectItemList(category => category.Name,
                    category => category.Id.ToString(),
                    emptyItemText: "Select an article list...");
        }
    }
}