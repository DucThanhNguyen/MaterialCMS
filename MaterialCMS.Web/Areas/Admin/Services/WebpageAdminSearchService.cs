using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;
using NHibernate;
using NHibernate.Criterion;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class WebpageAdminSearchService : IWebpageAdminSearchService
    {
        private readonly ISession _session;

        public WebpageAdminSearchService(ISession session)
        {
            _session = session;
        }

        public IPagedList<Webpage> Search(WebpageSearchQuery searchQuery)
        {
            var query = _session.QueryOver<Webpage>().Where(x => x.Parent.Id == searchQuery.ParentId);

            if (!string.IsNullOrWhiteSpace(searchQuery.Query))
            {
                query = query.Where(x => x.Name.IsInsensitiveLike(searchQuery.Query, MatchMode.Anywhere));
            }

            return query.Paged(searchQuery.Page);
        }
    }
}