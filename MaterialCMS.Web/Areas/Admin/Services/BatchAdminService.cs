using System.Linq;
using MaterialCMS.Batching.Entities;
using MaterialCMS.Helpers;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;
using NHibernate;
using NHibernate.Linq;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class BatchAdminService : IBatchAdminService
    {
        private readonly ISession _session;

        public BatchAdminService(ISession session)
        {
            _session = session;
        }

        public IPagedList<Batch> Search(BatchSearchModel searchModel)
        {
            return _session.Query<Batch>().OrderByDescending(batch => batch.Id).ToPagedList(searchModel.Page);
        }
    }
}