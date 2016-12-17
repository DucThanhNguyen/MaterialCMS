using System.Web.Mvc;
using MaterialCMS.Services.FileMigration;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class FileMigrationController : MaterialCMSAdminController
    {
        private readonly IFileMigrationService _fileMigrationService;

        public FileMigrationController(IFileMigrationService fileMigrationService)
        {
            _fileMigrationService = fileMigrationService;
        }

        public PartialViewResult Show()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Migrate()
        {
            FileMigrationResult result = _fileMigrationService.MigrateFiles();

            if (result.MigrationRequired)
                TempData.SuccessMessages().Add(result.Message);
            else
                TempData.InfoMessages().Add(result.Message);

            return RedirectToAction("FileSystem", "Settings");
        }
    }
}