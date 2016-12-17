using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web.FormProperties;

namespace MaterialCMS.Shortcodes.Forms
{
    public class ValidationMessaageRenderer : IValidationMessaageRenderer
    {
        public TagBuilder AppendRequiredMessage(FormProperty formProperty)
        {
            var tagBuilder = new TagBuilder("span");
            tagBuilder.AddCssClass("field-validation-valid");
            tagBuilder.Attributes["data-valmsg-for"] = formProperty.Name;//.GetHtmlId();
            tagBuilder.Attributes["data-valmsg-replace"] = "true";
            //data-valmsg-for="LastName" data-valmsg-replace="true"
            return tagBuilder;
        }
    }
}