using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface IFormRenderer
    {
        string RenderForm(Webpage webpage, FormSubmittedStatus submitted);
    }
}