using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Models;

namespace MaterialCMS.Services
{
    public interface IWebpageUrlService
    {
        string Suggest(Webpage parent, SuggestParams suggestParams);
    }
}