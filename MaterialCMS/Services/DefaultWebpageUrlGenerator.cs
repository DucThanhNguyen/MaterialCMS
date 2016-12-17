using System.Text;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;

namespace MaterialCMS.Services
{
    public sealed class DefaultWebpageUrlGenerator : IWebpageUrlGenerator
    {
        public string GetUrl(string pageName, Webpage parent, bool useHierarchy)
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

            stringBuilder.Append(SeoHelper.TidyUrl(pageName));
            return stringBuilder.ToString();
        }
    }
}