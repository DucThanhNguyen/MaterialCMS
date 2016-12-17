using System.Web.Routing;

namespace MaterialCMS.Website.Routing
{
    public static class MaterialCMSStandardExecutionExtensions
    {
        private const string DataTokenKey = "is-standard-execution";

        public static void MarkAsStandardExecution(this RouteData routeData)
        {
            routeData.DataTokens[DataTokenKey] = true;
        }

        public static bool IsStandardExecution(this RouteData routeData)
        {
            return routeData != null && routeData.DataTokens != null && routeData.DataTokens.ContainsKey(DataTokenKey);
        }
    }
}