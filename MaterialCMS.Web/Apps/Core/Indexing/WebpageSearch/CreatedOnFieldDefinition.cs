using System.Collections.Generic;
using Lucene.Net.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Web.Apps.Core.Indexing.WebpageSearch
{
    public class CreatedOnFieldDefinition : StringFieldDefinition<WebpageSearchIndexDefinition, Webpage>
    {
        public CreatedOnFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "createdon", index: Field.Index.NOT_ANALYZED)
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            yield return DateTools.DateToString(obj.CreatedOn, DateTools.Resolution.SECOND);
        }
    }
}