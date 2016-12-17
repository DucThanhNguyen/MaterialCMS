using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ISetWebpageAdminViewData
    {
        void SetViewData<T>(T webpage, ViewDataDictionary viewData) where T : Webpage;
    }
}