using System.Collections.Generic;
using System.Text.RegularExpressions;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Indexing.Management;

namespace MaterialCMS.Web.Apps.Core.Indexing.WebpageSearch
{
    public class BodyContentFieldDefinition : StringFieldDefinition<WebpageSearchIndexDefinition, Webpage>
    {
        public BodyContentFieldDefinition(ILuceneSettingsService luceneSettingsService)
            : base(luceneSettingsService, "bodycontent")
        {
        }

        protected override IEnumerable<string> GetValues(Webpage obj)
        {
            yield return RemoveTags(obj.BodyContent);
        }

        private string RemoveTags(string data)
        {
            string trim = Regex.Replace(data ?? string.Empty, @"<[^>]+>|&nbsp;", " ").Trim();
            return Regex.Replace(trim, @"\s{2,}", " ");
        }
    }
}