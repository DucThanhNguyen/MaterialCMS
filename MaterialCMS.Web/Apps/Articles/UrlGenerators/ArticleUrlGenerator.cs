using System.Text;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using MaterialCMS.Web.Apps.Articles.Pages;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Apps.Articles.UrlGenerators
{
    public class ArticleUrlGenerator : WebpageUrlGenerator<Article>
    {
        public override string GetUrl(string pageName, Webpage parent, bool useHierarchy)
        {
            var stringBuilder = new StringBuilder();

            if (useHierarchy)
            {
                //get breadcrumb from parent
                if (parent != null)
                {
                    stringBuilder.Insert(0, SeoHelper.TidyUrl(parent.UrlSegment) + "/");
                }
            }
            //add page name

            stringBuilder.AppendFormat("{0:yyyy/MM/}", CurrentRequestData.Now);
            stringBuilder.Append(SeoHelper.TidyUrl(pageName));
            return stringBuilder.ToString();
        }
    }
}