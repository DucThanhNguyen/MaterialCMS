using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface IValidationMessaageRenderer
    {
        TagBuilder AppendRequiredMessage(FormProperty formProperty);
    }
}