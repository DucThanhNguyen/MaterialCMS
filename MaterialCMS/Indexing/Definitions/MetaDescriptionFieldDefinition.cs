using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Entities.Indexes;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Indexing.Definitions
{
    public class MetaDescriptionFieldDefinition : StringFieldDefinition<AdminWebpageIndexDefinition, Webpage>
    {
        public MetaDescriptionFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "metadescription")
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            if (obj.MetaDescription != null) yield return obj.MetaDescription;
        }
    }
}