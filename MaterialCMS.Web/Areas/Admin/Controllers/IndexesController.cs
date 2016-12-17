using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Indexing.Management;
using MaterialCMS.Search;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class IndexesController : MaterialCMSAdminController
    {
        private readonly IIndexAdminService _indexAdminService;

        public IndexesController(IIndexAdminService indexAdminService)
        {
            _indexAdminService = indexAdminService;
        }

        [HttpGet]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.View)]
        public ViewResult Index()
        {
            ViewData["universal-search-index-info"] = _indexAdminService.GetUniversalSearchIndexInfo();
            return View(_indexAdminService.GetIndexes());
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.Reindex)]
        public RedirectToRouteResult Reindex(string type)
        {
            _indexAdminService.Reindex(type);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.Create)]
        public RedirectToRouteResult Create(string type)
        {
            _indexAdminService.Reindex(type);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.Optimize)]
        public RedirectToRouteResult Optimise(string type)
        {
            _indexAdminService.Optimise(type);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.SetBoosts)]
        public ViewResult Boosts(string type)
        {
            return View(_indexAdminService.GetBoosts(type));
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.SetBoosts)]
        public RedirectToRouteResult Boosts(List<LuceneFieldBoost> boosts)
        {
            _indexAdminService.SaveBoosts(boosts);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [MaterialCMSACLRule(typeof(IndexACL), IndexACL.Reindex)]
        public RedirectToRouteResult ReindexUniversalSearch()
        {
            _indexAdminService.ReindexUniversalSearch();
            TempData.SuccessMessages().Add("Univeral Search reindexed");
            return RedirectToAction("Index");
        }

        public ActionResult OptimiseUniversalSearch()
        {
            _indexAdminService.OptimiseUniversalSearch();
            TempData.SuccessMessages().Add("Univeral Search optimised");
            return RedirectToAction("Index");
        }
    }
}