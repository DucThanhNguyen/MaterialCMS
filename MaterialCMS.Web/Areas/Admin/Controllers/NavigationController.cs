using System.Web.Mvc;
using MaterialCMS.Models;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class NavigationController : MaterialCMSAdminController
    {
        private readonly ITreeNavService _treeNavService;

        public NavigationController(ITreeNavService treeNavService)
        {
            _treeNavService = treeNavService;
        }

        public PartialViewResult WebSiteTree(int? id)
        {
            AdminTree admintree = _treeNavService.GetWebpageNodes(id);
            return PartialView("TreeList", admintree);
        }

        public PartialViewResult MediaTree(int? id)
        {
            AdminTree admintree = _treeNavService.GetMediaCategoryNodes(id);
            return PartialView("TreeList", admintree);
        }

        public PartialViewResult LayoutTree(int? id)
        {
            AdminTree admintree = _treeNavService.GetLayoutNodes(id);
            return PartialView("TreeList", admintree);
        }
    }
}