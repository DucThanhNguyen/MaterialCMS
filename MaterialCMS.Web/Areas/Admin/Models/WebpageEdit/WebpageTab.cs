using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Areas.Admin.Models.WebpageEdit
{
    public abstract class WebpageTab : WebpageTabBase
    {
        public abstract string TabHtmlId { get; }
        public abstract void RenderTabPane(HtmlHelper<Webpage> html, Webpage webpage);
    }
}