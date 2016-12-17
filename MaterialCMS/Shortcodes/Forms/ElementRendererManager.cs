using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;
using MaterialCMS.Settings;
using Ninject;

namespace MaterialCMS.Shortcodes.Forms
{
    public class ElementRendererManager : IElementRendererManager
    {
        private readonly IKernel _kernel;

        public ElementRendererManager(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IFormElementRenderer GetElementRenderer<T>(T property) where T : FormProperty
        {
            return _kernel.Get(typeof(IFormElementRenderer<>).MakeGenericType(property.GetType())) as IFormElementRenderer;
        }

        public TagBuilder GetElementContainer(FormRenderingType formRendererType, FormProperty property)
        {
            if (formRendererType == FormRenderingType.Bootstrap3)
            {
                if (property is TextBox || property is TextArea || property is DropDownList || property is FileUpload)
                {
                    var elementContainer = new TagBuilder("div");
                    elementContainer.AddCssClass("form-group");
                    return elementContainer;
                }
            }
            return null;
        }
    }
}