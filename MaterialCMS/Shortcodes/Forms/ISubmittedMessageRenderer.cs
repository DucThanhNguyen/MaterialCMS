using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface ISubmittedMessageRenderer
    {
        TagBuilder AppendSubmittedMessage(Webpage webpage, FormSubmittedStatus submittedStatus);
    }
}