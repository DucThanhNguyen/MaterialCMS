using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Services.Sitemaps
{
    public interface IGetSitemapPath
    {
        string GetPath(Site site);
        bool FileExists(string path);
    }
}