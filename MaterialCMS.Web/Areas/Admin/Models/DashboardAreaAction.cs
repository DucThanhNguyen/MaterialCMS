using System.Web.Mvc;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class DashboardAreaAction : ActionFilterAttribute
    {
        public DashboardArea DashboardArea { get; set; }
    }
}