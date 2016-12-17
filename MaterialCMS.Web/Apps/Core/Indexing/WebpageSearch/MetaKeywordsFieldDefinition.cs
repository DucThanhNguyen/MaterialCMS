using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Web.Apps.Core.Indexing.WebpageSearch
{
    public class MetaKeywordsFieldDefinition : StringFieldDefinition<WebpageSearchIndexDefinition, Webpage>
    {
        public MetaKeywordsFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "metakeywords")
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            if (obj.MetaKeywords != null) yield return obj.MetaKeywords;
        }
    }
}