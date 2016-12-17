using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis;

namespace MaterialCMS.Web.Areas.Admin.Services.SEOAnalysis
{
    public interface ISEOAnalysisService
    {
        SEOAnalysisResult Analyze(Webpage webpage, string analysisTerm);
        void UpdateAnalysisTerm(Webpage webpage);
    }
}