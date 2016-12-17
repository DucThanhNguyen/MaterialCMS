using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Website;

namespace MaterialCMS.Helpers
{
    public static class MaterialCMSPageExtensions
    {
        public const string PageTitleKey = "page-title";
        public const string PageDescriptionKey = "page-description";
        public const string PageKeywordsKey = "page-keywords";
        public static string PageTitle<T>(this MaterialCMSPage<T> page) where T : Webpage
        {
            return page.ViewData[PageTitleKey] as string ?? page.Model.GetPageTitle();
        }

        public static string Description<T>(this MaterialCMSPage<T> page) where T : Webpage
        {
            return page.ViewData[PageDescriptionKey] as string ?? page.Model.MetaDescription;
        }

        public static string Keywords<T>(this MaterialCMSPage<T> page) where T : Webpage
        {
            return page.ViewData[PageKeywordsKey] as string ?? page.Model.MetaKeywords;
        }

        public static string GetPageTitle<T>(this T webpage) where T : Webpage
        {
            return !string.IsNullOrWhiteSpace(webpage.MetaTitle) ? webpage.MetaTitle : webpage.Name;
        }
    }
}