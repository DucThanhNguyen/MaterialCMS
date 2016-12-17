using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;
using MaterialCMS.Settings;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface IElementRendererManager
    {
        IFormElementRenderer GetElementRenderer<T>(T property) where T : FormProperty;
        TagBuilder GetElementContainer (FormRenderingType formRendererType, FormProperty property);
    }
}