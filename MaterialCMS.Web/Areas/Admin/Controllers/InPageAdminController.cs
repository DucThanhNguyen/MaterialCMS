using System.Web.Mvc;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    [MaterialCMSACLRule(typeof (AdminBarACL), AdminBarACL.Show, ReturnEmptyResult = true)]
    public class InPageAdminController : MaterialCMSAdminController
    {
        private readonly IInPageAdminService _inPageAdminService;

        public InPageAdminController(IInPageAdminService inPageAdminService)
        {
            _inPageAdminService = inPageAdminService;
        }

        public ActionResult InPageEditor(Webpage page)
        {
            return PartialView("InPageEditor", page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveBodyContent(UpdatePropertyData updatePropertyData)
        {
            return Json(_inPageAdminService.SaveBodyContent(updatePropertyData));
        }

        [ValidateInput(false)]
        public string GetUnformattedBodyContent(GetPropertyData getPropertyData)
        {
            return _inPageAdminService.GetUnformattedBodyContent(getPropertyData);
        }

        [ValidateInput(false)]
        public string GetFormattedBodyContent(GetPropertyData getPropertyData)
        {
            return _inPageAdminService.GetFormattedBodyContent(getPropertyData, this);
        }
    }
}