using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IWebpageTreeNavListing
    {
        AdminTree GetTree(int? id);
        bool HasChildren(int id);
    }
}