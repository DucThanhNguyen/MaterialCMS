using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Website
{
    public interface IProcessWebpageViews
    {
        void Process(ViewResult result, Webpage webpage);
    }
}