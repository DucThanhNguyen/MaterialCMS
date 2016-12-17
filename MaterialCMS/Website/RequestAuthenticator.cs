using System.Threading;
using System.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using Ninject;

namespace MaterialCMS.Website
{
    public static class RequestAuthenticator
    {
        public static void Authenticate(HttpRequest request)
        {
            if (CurrentRequestData.CurrentContext.User != null)
            {
                var currentUser = MaterialCMSKernel.Kernel.Get<IUserLookup>()
                    .GetCurrentUser(CurrentRequestData.CurrentContext);
                if (!request.Url.AbsolutePath.StartsWith("/signalr/") && (currentUser == null ||
                                                                          !currentUser.IsActive))
                    MaterialCMSKernel.Kernel.Get<IAuthorisationService>().Logout();
                else
                {
                    CurrentRequestData.CurrentUser = currentUser;
                    Thread.CurrentThread.CurrentCulture = currentUser.GetUICulture();
                    Thread.CurrentThread.CurrentUICulture = currentUser.GetUICulture();
                }
            }
        }
    }
}