using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services.CloneSite
{
    public interface ICloneWebpageSiteParts
    {
        void Clone(Webpage @from, Webpage to, SiteCloneContext siteCloneContext);
    }
}