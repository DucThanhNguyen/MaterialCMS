using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Indexes;
using MaterialCMS.Indexing.Management;
using MaterialCMS.Website;

namespace MaterialCMS.Indexing.Definitions
{
    public class NameFieldDefinition : StringFieldDefinition<AdminWebpageIndexDefinition, Webpage>
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