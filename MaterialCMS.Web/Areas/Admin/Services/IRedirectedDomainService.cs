using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IRedirectedDomainService
    {
        void Save(RedirectedDomain domain);
        void Delete(RedirectedDomain domain);
    }
}