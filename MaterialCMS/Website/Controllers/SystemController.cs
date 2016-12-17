using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MaterialCMS.Entities;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Entities.People;
using MaterialCMS.Website.ActionResults;

namespace MaterialCMS.Website.Controllers
{
    [MaterialCMSAuthorize(Roles = UserRole.Administrator)]
    [ValidateInput(false)]
    public abstract class SystemController : Controller
    {
        public new HttpRequestBase Request
        {
            get { return RequestMock ?? base.Request; }
        }

        public HttpRequestBase RequestMock { get; set; }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding,
                                           JsonRequestBehavior behavior)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new JsonNetResult
                {
                    ContentEncoding = contentEncoding,
                    ContentType = contentType,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = data
                };
        }
        protected JsonResult Json(string data)
        {
            return new JsonNetResult
                {
                    ContentEncoding = null,
                    ContentType = null,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    JsonData = data
                };
        }
    }
}