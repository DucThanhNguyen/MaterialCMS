using System.Collections.Generic;
using Lucene.Net.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Indexes;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Indexing.Definitions
{
    public class ParentIdFieldDefinition : StringFieldDefinition<AdminWebpageIndexDefinition, Webpage>
    {
        public ParentIdFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "parentid", index:Field.Index.NOT_ANALYZED)
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            yield return obj.ParentId.ToString();
        }
    }
}