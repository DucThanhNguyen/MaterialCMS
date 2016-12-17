using MaterialCMS.Entities.Documents.Metadata;
using MaterialCMS.Web.Apps.Core.Pages;

namespace MaterialCMS.Web.Apps.Core.Metadata
{
    public class SearchPageMetaData : DocumentMetadataMap<SearchPage>
    {
        public override string IconClass
        {
            get { return "glyphicon glyphicon-search"; }
        }
        public override string WebGetController
        {
            get { return "SearchPage"; }
        }
        public override string WebPostController
        {
            get { return "SearchPage"; }
        }
    }
}