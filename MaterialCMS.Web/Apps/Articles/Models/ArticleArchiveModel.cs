using System.Collections.Generic;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Web.Apps.Articles.Widgets;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Articles.Models
{
    public class ArticleArchiveModel
    {
        public ArticleList ArticleList { get; set; }
        public ArticleArchive ArticleArchive { get; set; }
        public IList<ArchiveModel> ArticleYearsAndMonths { get; set; }
        public string Year { get { return CurrentRequestData.CurrentContext.Request["year"]; } }
        public string Month { get { return CurrentRequestData.CurrentContext.Request["year"]; } }
    }
}