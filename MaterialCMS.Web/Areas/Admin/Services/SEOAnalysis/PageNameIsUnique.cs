using System.Collections.Generic;
using HtmlAgilityPack;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Web.Areas.Admin.Controllers;
using MaterialCMS.Web.Areas.Admin.Models.SEOAnalysis;
using NHibernate;

namespace MaterialCMS.Web.Areas.Admin.Services.SEOAnalysis
{
    public class PageNameIsUnique : BaseSEOAnalysisFacetProvider
    {
        private readonly ISession _session;

        public PageNameIsUnique(ISession session)
        {
            _session = session;
        }

        public override IEnumerable<SEOAnalysisFacet> GetFacets(Webpage webpage, HtmlNode document, string analysisTerm)
        {
            bool anyWithSameTitle =
                _session.QueryOver<Webpage>()
                    .Where(page => page.Site.Id == webpage.Site.Id && page.Id != webpage.Id && page.Name == webpage.Name)
                    .Any();

            if (anyWithSameTitle)
                yield return
                    GetFacet("Any other pages with same title?", SEOAnalysisStatus.Error, "The title is not unique");
            else
                yield return
                    GetFacet("Any other pages with same title?", SEOAnalysisStatus.Success, "The title is unique");
        }
    }
}