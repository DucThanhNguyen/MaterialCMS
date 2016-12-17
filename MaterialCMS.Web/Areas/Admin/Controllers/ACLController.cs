using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using MaterialCMS.ACL;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Models;
using MaterialCMS.Services;
using MaterialCMS.Settings;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class ACLController : MaterialCMSAdminController
    {
        private readonly IACLService _aclService;
        private readonly ACLSettings _aclSettings;
        private readonly IConfigurationProvider _configurationProvider;

        public ACLController(IACLService aclService, ACLSettings aclSettings, IConfigurationProvider configurationProvider)
        {
            _aclService = aclService;
            _aclSettings = aclSettings;
            _configurationProvider = configurationProvider;
        }

        [HttpGet]
        [MaterialCMSACLRule(typeof(AclAdminACL), AclAdminACL.View)]
        public ViewResult Index()
        {
            ViewData["settings"] = _aclSettings;
            return View(_aclService.GetACLModel());
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(AclAdminACL), AclAdminACL.Edit)]
        public RedirectToRouteResult Index([IoCModelBinder(typeof(ACLUpdateModelBinder))] List<ACLUpdateRecord> model)
        {
            _aclService.UpdateACL(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(AclAdminACL), AclAdminACL.Edit)]
        public ActionResult Disable()
        {
            _aclSettings.ACLEnabled = false;
            _configurationProvider.SaveSettings(_aclSettings);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [MaterialCMSACLRule(typeof(AclAdminACL), AclAdminACL.Edit)]
        public ActionResult Enable()
        {
            _aclSettings.ACLEnabled = true;
            _configurationProvider.SaveSettings(_aclSettings);
            return RedirectToAction("Index");
        }
    }
}