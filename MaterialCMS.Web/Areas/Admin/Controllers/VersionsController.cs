using System.Web.Mvc;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class VersionsController : MaterialCMSAdminController
    {
        private readonly IDocumentVersionsAdminService _service;

        public VersionsController(IDocumentVersionsAdminService service)
        {
            _service = service;
        }

        public PartialViewResult Show(Document document, int page = 1)
        {
            return PartialView(_service.GetVersions(document, page));
        }

        [HttpGet]
        public PartialViewResult Revert(DocumentVersion documentVersion)
        {
            return PartialView(documentVersion);
        }

        [HttpPost]
        [ActionName("Revert")]
        public RedirectToRouteResult Revert_POST(DocumentVersion documentVersion)
        {
            _service.RevertToVersion(documentVersion);
            return RedirectToAction("Edit", "Webpage", new { id = documentVersion.Document.Id });
        }
    }
}