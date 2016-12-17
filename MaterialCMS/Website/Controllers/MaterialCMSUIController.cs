using MaterialCMS.Helpers;

namespace MaterialCMS.Website.Controllers
{
    [HandleWebpageViews]
    public abstract class MaterialCMSUIController : MaterialCMSController
    {
        public void SetPageTitle(string pageTitle)
        {
            ViewData[MaterialCMSPageExtensions.PageTitleKey] = pageTitle;
        }

        public void SetPageMetaDescription(string pageDescription)
        {
            ViewData[MaterialCMSPageExtensions.PageDescriptionKey] = pageDescription;
        }

        public void SetPageMetaKeywords(string pageKeywords)
        {
            ViewData[MaterialCMSPageExtensions.PageKeywordsKey] = pageKeywords;
        }
    }
}