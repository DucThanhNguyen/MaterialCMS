using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    public abstract class WebpageUrlGenerator<T> : IWebpageUrlGenerator where T : Webpage
    {
        public abstract string GetUrl(string pageName, Webpage parent, bool useHierarchy);
    }
}