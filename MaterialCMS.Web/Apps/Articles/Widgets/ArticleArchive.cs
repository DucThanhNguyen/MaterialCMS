using System.ComponentModel;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Articles.Widgets
{
    [OutputCacheable(PerPage = true)]
    public class ArticleArchive : Widget
    {
        public virtual ArticleList ArticleList { get; set; }

        [DisplayName("Show Name As Title")]
        public virtual bool ShowNameAsTitle { get; set; }
    }
}