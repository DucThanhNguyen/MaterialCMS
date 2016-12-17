using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website;

namespace MaterialCMS.Web.Areas.Admin.Helpers
{
    public static class LocalisedScriptHtmlHelper
    {
        public static void RenderLocalisedScripts(this HtmlHelper helper)
        {
            var localisedScripts = helper.GetAll<ILocalisedScripts>();
            var scriptList = localisedScripts.SelectMany(scripts => scripts.Files).ToArray();
            helper.ViewContext.Writer.Write(Scripts.Render(scriptList));
        }
    }
}