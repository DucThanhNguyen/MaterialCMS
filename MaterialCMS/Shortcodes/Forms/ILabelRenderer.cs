using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface ILabelRenderer
    {
        TagBuilder AppendLabel(FormProperty formProperty);
    }
}