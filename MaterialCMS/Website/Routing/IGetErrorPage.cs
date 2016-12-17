using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website.Routing
{
    public interface IGetErrorPage
    {
        Webpage GetPage(int code);
    }
}