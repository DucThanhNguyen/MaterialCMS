using System.Web.Mvc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Services
{
    public interface IUniquePageService
    {
        RedirectResult RedirectTo<T>(object routeValues = null) where T : Webpage, IUniquePage;
        RedirectResult PermanentRedirectTo<T>(object routeValues = null) where T : Webpage, IUniquePage;
        T GetUniquePage<T>() where T : Document, IUniquePage;
    }
}