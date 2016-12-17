using System;
using System.Web.Mvc;
using MaterialCMS.HealthChecks;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Web.Areas.Admin.Services.Dashboard;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class HealthCheckController : MaterialCMSAdminController
    {
        private readonly IHealthCheckService _healthCheckService;

        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [DashboardAreaAction(DashboardArea = DashboardArea.RightColumn, Order = 100)]
        public PartialViewResult List()
        {
            return PartialView(_healthCheckService.GetHealthChecks());
        }

        [HttpGet]
        public JsonResult Process([IoCModelBinder(typeof(HealthCheckProcessorModelBinder))] IHealthCheck healthCheck)
        {
            return Json(healthCheck == null ? new HealthCheckResult() : healthCheck.PerformCheck(), JsonRequestBehavior.AllowGet);
        }
    }
}