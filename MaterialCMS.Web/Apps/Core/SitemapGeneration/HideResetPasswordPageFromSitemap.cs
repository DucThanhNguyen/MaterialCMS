using System.Xml;
using System.Xml.Linq;
using MaterialCMS.Services.Sitemaps;
using MaterialCMS.Web.Apps.Core.Pages;

namespace MaterialCMS.Web.Apps.Core.SitemapGeneration
{
    public class HideResetPasswordPageFromSitemap : SitemapGenerationInfo<ResetPasswordPage>
    {
        public override bool ShouldAppend(ResetPasswordPage webpage)
        {
            return false;
        }

        public override void Append(ResetPasswordPage webpage, XElement urlset, XDocument xmlDocument)
        {
        }
    }
}