using MaterialCMS.Entities.Documents.Metadata;
using MaterialCMS.Web.Apps.Core.Pages;

namespace MaterialCMS.Web.Apps.Core.Metadata
{
    public class UserAccountMetadata : DocumentMetadataMap<UserAccountPage>
    {
        public override string IconClass
        {
            get { return "glyphicon glyphicon-user"; }
        }

        public override string WebGetAction
        {
            get { return "Show"; }
        }

        public override string WebGetController
        {
            get { return "UserAccount"; }
        }
    }
}