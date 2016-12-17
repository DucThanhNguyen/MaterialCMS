using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ITreeNavService
    {
        AdminTree GetWebpageNodes(int? id);
        bool WebpageHasChildren(int id);

        AdminTree GetMediaCategoryNodes(int? id);
        AdminTree GetLayoutNodes(int? id);
    }
}