using System.Collections.Generic;
using HtmlAgilityPack;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis;

namespace MaterialCMS.Web.Areas.Admin.Services.SEOAnalysis
{
    public class TitleIsCorrectLength : BaseSEOAnalysisFacetProvider
    {
        public override IEnumerable<SEOAnalysisFacet> GetFacets(Webpage webpage, HtmlNode document, string analysisTerm)
        {
            string titleText = document.GetElementText("title") ?? string.Empty;

            if (titleText.Length < 50)
                yield return GetFacet("Title length", SEOAnalysisStatus.Error, "The title should be at least 50 characters long");
            else if (titleText.Length > 90)
                yield return
                    GetFacet("Title length", SEOAnalysisStatus.Error, "The title should be at most 90 characters long");
            else
                yield return
                    GetFacet("Title length", SEOAnalysisStatus.Success,
                        "The title is of optimal length (50-90 characters)");
        }
    }
}