using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public abstract class BaseAssignWebpageAdminViewData
    {
        public abstract void AssignViewDataBase(Webpage webpage, ViewDataDictionary viewData);
    }

    public abstract class BaseAssignWebpageAdminViewData<T> : BaseAssignWebpageAdminViewData where T : Webpage
    {
        public abstract void AssignViewData(T webpage, ViewDataDictionary viewData);

        public override sealed void AssignViewDataBase(Webpage webpage, ViewDataDictionary viewData)
        {
            AssignViewData(webpage as T, viewData);
        }
    }
}