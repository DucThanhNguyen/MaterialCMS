using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public abstract class WebpageTreeNavListing<T> : IWebpageTreeNavListing where T : Webpage
    {
        public abstract AdminTree GetTree(int? id);
        public abstract bool HasChildren(int id);
    }
}