using System.Collections.Generic;
using Lucene.Net.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Web.Apps.Core.Indexing.WebpageSearch
{
    public class PublishedFieldDefinition : StringFieldDefinition<WebpageSearchIndexDefinition, Webpage>
    {
        public PublishedFieldDefinition(ILuceneSettingsService luceneSettingsService) : base(luceneSettingsService, "published", index: Field.Index.NOT_ANALYZED)
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            yield return obj.Published.ToString();
        }
    }
}