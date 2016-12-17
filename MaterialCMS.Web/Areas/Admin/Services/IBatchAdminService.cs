using MaterialCMS.Batching.Entities;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Controllers;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IBatchAdminService
    {
        IPagedList<Batch> Search(BatchSearchModel searchModel);
    }
}