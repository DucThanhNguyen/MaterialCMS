using MaterialCMS.Entities.Documents;
using MaterialCMS.Models;
using MaterialCMS.Paging;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class VersionsModel : AsyncListModel<DocumentVersion>
    {
        public VersionsModel(IPagedList<DocumentVersion> items, int id)
            : base(items, id)
        {
        }
    }
}