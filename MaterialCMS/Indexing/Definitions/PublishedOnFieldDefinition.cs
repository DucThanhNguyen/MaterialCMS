using System;
using System.Collections.Generic;
using Lucene.Net.Documents;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Indexes;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Indexing.Definitions
{
    public class PublishedOnFieldDefinition : StringFieldDefinition<AdminWebpageIndexDefinition, Webpage>
    {
        public PublishedOnFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "publishon", index: Field.Index.NOT_ANALYZED)
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            yield return DateTools.DateToString(obj.PublishOn.GetValueOrDefault(DateTime.MaxValue), DateTools.Resolution.SECOND);
        }
    }
}