using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Indexes;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Indexing.Definitions
{
    public class MetaTitleFieldDefinition : StringFieldDefinition<AdminWebpageIndexDefinition, Webpage>
    {
        public MetaTitleFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "metatitle")
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            if (obj.MetaTitle != null) yield return obj.MetaTitle;
        }
    }
}