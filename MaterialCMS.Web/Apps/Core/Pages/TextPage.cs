using System.ComponentModel;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Web.Apps.Core.Pages
{
    public class TextPage : Webpage
    {
        [DisplayName("Featured Image")]
        public virtual string FeatureImage { get; set; }
    }
}