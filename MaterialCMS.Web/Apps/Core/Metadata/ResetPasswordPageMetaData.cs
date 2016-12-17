using System;
using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Metadata;
using MaterialCMS.Web.Apps.Core.Pages;

namespace MaterialCMS.Web.Apps.Core.Metadata
{
    public class ResetPasswordPageMetadata : DocumentMetadataMap<ResetPasswordPage>
    {
        public override string IconClass
        {
            get { return "glyphicon glyphicon-user"; }
        }

        public override string WebGetController
        {
            get { return "Login"; }
        }

        public override string WebGetAction
        {
            get { return "PasswordReset"; }
        }

        public override string WebPostController
        {
            get { return "Login"; }
        }

        public override string WebPostAction
        {
            get { return "PasswordReset"; }
        }

        public override IEnumerable<Type> ChildrenList
        {
            get { yield break; }
        }

        public override ChildrenListType ChildrenListType
        {
            get { return ChildrenListType.WhiteList; }
        }
    }
}