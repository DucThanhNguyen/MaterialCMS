using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Areas.Admin.Helpers;
using MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis;

namespace MaterialCMS.Web.Areas.Admin.Services.SEOAnalysis
{
    public class SubheadingsContainingTerm : BaseSEOAnalysisFacetProvider
    {
        public override IEnumerable<SEOAnalysisFacet> GetFacets(Webpage webpage, HtmlNode document, string analysisTerm)
        {
            var subheadings = document.GetElementsOfType("h2").ToList();
            if (!subheadings.Any())
            {
                yield return GetFacet("Subheadings", SEOAnalysisStatus.CanBeImproved, "The page contains no subheadings (i.e. h2 tags)");
                yield break;
            }
            var matchingNodes = subheadings.FindAll(node => node.InnerHtml.Contains(analysisTerm, StringComparison.OrdinalIgnoreCase));
            if (!matchingNodes.Any())
                yield return
                    GetFacet("Subheadings", SEOAnalysisStatus.CanBeImproved, string.Format("{0} of the {1} subheadings contain the target term", matchingNodes.Count(), subheadings.Count()));
            else
                yield return
                    GetFacet("Subheadings", SEOAnalysisStatus.Success, string.Format("{0} of the {1} subheadings contain the target term", matchingNodes.Count(), subheadings.Count()));
        }
    }
}