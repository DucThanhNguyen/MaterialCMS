using System.ComponentModel;

namespace MaterialCMS.Entities.Documents.Web.FormProperties
{
    public class TextBox : FormProperty
    {
        [DisplayName("Placeholder Text")]
        public virtual string PlaceHolder { get; set; }
    }
}