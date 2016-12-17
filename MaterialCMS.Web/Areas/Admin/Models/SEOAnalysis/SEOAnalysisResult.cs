using System.Collections.Generic;
using MaterialCMS.Web.Areas.Admin.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis
{
    public class SEOAnalysisResult : List<SEOAnalysisFacet>
    {
        public SEOAnalysisResult() { }
        public SEOAnalysisResult(IEnumerable<SEOAnalysisFacet> facets)
            : base(facets)
        {

        }
    }
}