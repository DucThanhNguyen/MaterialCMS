using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    internal interface IWebpageUrlGenerator
    {
        string GetUrl(string pageName, Webpage parent, bool useHierarchy);
    }
}