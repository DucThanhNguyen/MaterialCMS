using System;
using System.Web.Routing;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Website.Routing
{
    public interface IHandleStandardMaterialCMSPageExecution
    {
        void Handle(RequestContext context, Webpage webpage, Action<MaterialCMSUIController> beforeExecute = null);
    }
}