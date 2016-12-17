using System.Web;
using System.Web.Hosting;

namespace MaterialCMS.Website
{
    public class OutOfContextServerUtility : HttpServerUtilityBase
    {
        public override string MapPath(string path)
        {
            return HostingEnvironment.MapPath(path);
        }
    }
}