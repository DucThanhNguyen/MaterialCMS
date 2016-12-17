using System.Web.Mvc;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IInPageAdminService
    {
        SaveResult SaveBodyContent(UpdatePropertyData updatePropertyData);
        string GetUnformattedBodyContent(GetPropertyData getPropertyData);
        string GetFormattedBodyContent(GetPropertyData getPropertyData, Controller controller);
    }
}