using System.Collections.Generic;
using MaterialCMS.ACL;

namespace MaterialCMS.Web.Areas.Admin.ACL
{
    public class NotificationACL : ACLRule
    {
        public const string Delete = "Delete";

        public override string DisplayName
        {
            get { return "Notifications"; }
        }

        protected override List<string> GetOperations()
        {
            return new List<string>
                   {
                       Delete
                   };
        }
    }
}