using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface ICustomFormRenderer
    {
        string GetForm(Webpage webpage, FormSubmittedStatus submittedStatus);
    }
}