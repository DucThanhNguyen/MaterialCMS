using System;
using MaterialCMS.ACL.Rules;
using MaterialCMS.Helpers;

namespace MaterialCMS.Website
{
    public class MaterialCMSAuthorizeAttribute : MaterialCMSBaseAuthorizationAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var currentUser = CurrentRequestData.CurrentUser;
            return base.AuthorizeCore(httpContext) && currentUser != null &&
                   currentUser.IsActive &&
                   currentUser.Email != null &&
                   currentUser.Email.Equals(httpContext.User.Identity.Name, StringComparison.OrdinalIgnoreCase) &&
                   currentUser.CanAccess<AdminAccessACL>(AdminAccessACL.Allowed);
        }
    }
}