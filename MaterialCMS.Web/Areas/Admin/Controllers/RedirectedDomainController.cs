using System.Web.Mvc;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class RedirectedDomainController : MaterialCMSAdminController
    {
        private readonly IRedirectedDomainService _redirectedDomainService;

        public RedirectedDomainController(IRedirectedDomainService redirectedDomainService)
        {
            _redirectedDomainService = redirectedDomainService;
        }

        [HttpGet]
        public PartialViewResult Add(Site site)
        {
            return PartialView(new RedirectedDomain {Site = site});
        }

        [HttpPost]
        public RedirectToRouteResult Add(RedirectedDomain domain)
        {
            _redirectedDomainService.Save(domain);
            return RedirectToAction("Edit", "Sites", new {id = domain.Site.Id});
        }

        public PartialViewResult Delete(RedirectedDomain domain)
        {
            return PartialView(domain);
        }

        [HttpPost]
        [ActionName("Delete")]
        public RedirectToRouteResult Delete_POST(RedirectedDomain domain)
        {
            Site site = domain.Site;
            _redirectedDomainService.Delete(domain);
            return RedirectToAction("Edit", "Sites", new {id = site.Id});
        }
    }
}