using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis;
using MaterialCMS.Web.Areas.Admin.Services.SEOAnalysis;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class SEOAnalysisController : MaterialCMSAdminController
    {
        private readonly ISEOAnalysisService _seoAnalysisService;

        public SEOAnalysisController(ISEOAnalysisService seoAnalysisService)
        {
            _seoAnalysisService = seoAnalysisService;
        }

        public PartialViewResult Analyze(Webpage webpage)
        {
            _seoAnalysisService.UpdateAnalysisTerm(webpage);
            SEOAnalysisResult result = _seoAnalysisService.Analyze(webpage, webpage.SEOTargetPhrase);
            return PartialView(result);
        }
    }
}