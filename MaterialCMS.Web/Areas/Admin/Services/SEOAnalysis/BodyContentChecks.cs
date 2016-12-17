using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis;

namespace MaterialCMS.Web.Areas.Admin.Services.SEOAnalysis
{
    public class BodyContentChecks : BaseSEOAnalysisFacetProvider
    {
        public override IEnumerable<SEOAnalysisFacet> GetFacets(Webpage webpage, HtmlNode document, string analysisTerm)
        {
            var text =
                (HtmlNode.CreateNode("<div>" + webpage.BodyContent + "</div>").InnerText ?? string.Empty).Replace(
                    Environment.NewLine, " ");

            if (text.Contains(analysisTerm, StringComparison.OrdinalIgnoreCase))
            {
                yield return
                    GetFacet("Body Content", SEOAnalysisStatus.Success,
                        string.Format("Body content contains '{0}'", analysisTerm));
            }
            else
            {
                yield return
                    GetFacet("Body Content", SEOAnalysisStatus.Error,
                        string.Format("Body content does not contain '{0}'", analysisTerm));
            }
        }
    }
}