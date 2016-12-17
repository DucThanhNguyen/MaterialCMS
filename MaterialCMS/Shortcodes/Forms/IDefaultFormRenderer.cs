using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface IDefaultFormRenderer
    {
        string GetDefault(Webpage webpage, FormSubmittedStatus submittedStatus);
    }
}