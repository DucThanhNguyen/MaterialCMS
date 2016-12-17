using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IWebpageBaseViewDataService
    {
        void SetAddPageViewData(ViewDataDictionary viewData, Webpage parent);
        void SetEditPageViewData(ViewDataDictionary viewData, Webpage page);
    }
}