using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface IDropDownListOptionRenderer
    {
        TagBuilder GetOption(FormListOption option, string existingValue);
    }
}