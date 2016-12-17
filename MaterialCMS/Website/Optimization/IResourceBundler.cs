using System.Web.Mvc;

namespace MaterialCMS.Website.Optimization
{
    public interface IResourceBundler
    {
        void AddScript(string virtualPath, string url);
        void AddCss(string virtualPath, string url);
        void GetScripts(ViewContext viewContext);
        void GetCss(ViewContext viewContext);
    }
}