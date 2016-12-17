using MaterialCMS.Entities.Documents.Layout;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    public interface IGetCurrentLayout
    {
        Layout Get(Webpage webpage);
    }
}