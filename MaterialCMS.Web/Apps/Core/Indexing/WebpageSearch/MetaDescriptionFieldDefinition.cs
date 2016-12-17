using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Web.Apps.Core.Indexing.WebpageSearch
{
    public class MetaDescriptionFieldDefinition : StringFieldDefinition<WebpageSearchIndexDefinition, Webpage>
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