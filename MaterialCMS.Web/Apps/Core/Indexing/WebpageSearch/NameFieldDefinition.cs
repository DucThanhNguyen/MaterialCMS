using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Web.Apps.Core.Indexing.WebpageSearch
{
    public class NameFieldDefinition : StringFieldDefinition<WebpageSearchIndexDefinition, Webpage>
    {
        public NameFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "name")
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            if (obj.Name != null) yield return obj.Name;
        }
    }
}