using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Models;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.ModelBinders;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Website.Binders;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class WebpageUrlController : MaterialCMSAdminController
    {
        private readonly IWebpageUrlService _webpageUrlService;

        public WebpageUrlController(IWebpageUrlService webpageUrlService)
        {
            _webpageUrlService = webpageUrlService;
        }

        public string Suggest(Webpage parent, [IoCModelBinder(typeof(SuggestParamsModelBinder))]SuggestParams suggestParams)
        {
            return _webpageUrlService.Suggest(parent, suggestParams);
        }
    }
}