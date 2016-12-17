using System.Collections.Generic;
using MaterialCMS.Web.Apps.Articles.Pages;

namespace MaterialCMS.Web.Apps.Articles.Models
{
    public class LatestXArticlesViewModel
    {
        public IList<Article> Articles { get; set; }
        public string Title { get; set; }
    }
}