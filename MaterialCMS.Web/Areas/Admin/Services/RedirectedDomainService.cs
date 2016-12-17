using MaterialCMS.Entities.Multisite;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class RedirectedDomainService : IRedirectedDomainService
    {
        private readonly ISession _session;

        public RedirectedDomainService(ISession session)
        {
            _session = session;
        }

        public void Save(RedirectedDomain domain)
        {
            if (domain.Site != null)
                domain.Site.RedirectedDomains.Add(domain);
            _session.Transact(session => session.Save(domain));
        }

        public void Delete(RedirectedDomain domain)
        {
            if (domain.Site != null)
                domain.Site.RedirectedDomains.Remove(domain);
            _session.Transact(session => session.Delete(domain));
        }
    }
}