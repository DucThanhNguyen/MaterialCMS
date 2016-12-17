using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;
using MaterialCMS.Settings;

namespace MaterialCMS.Shortcodes.Forms
{
    public interface IFormElementRenderer<in T> : IFormElementRenderer where T : FormProperty
    {
        TagBuilder AppendElement(T formProperty, string existingValue, FormRenderingType formRenderingType);
    }

    public interface IFormElementRenderer
    {
        TagBuilder AppendElement(FormProperty formProperty, string existingValue, FormRenderingType formRenderingType);
        bool IsSelfClosing { get; }
    }
}