using MaterialCMS.Entities.Multisite;

namespace MaterialCMS.Services.CloneSite
{
    public interface ICloneSiteParts
    {
        void Clone(Site @from, Site to, SiteCloneContext siteCloneContext);
    }
}