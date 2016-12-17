using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Services
{
    public interface ICurrentSiteLocator
    {
        Site GetCurrentSite();
    }
}