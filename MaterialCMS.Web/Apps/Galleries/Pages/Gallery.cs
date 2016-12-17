using System.ComponentModel;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Web.Apps.Core.Pages;

namespace MaterialCMS.Web.Apps.Galleries.Pages
{
    public class Gallery : TextPage
    {
        public virtual MediaCategory MediaGallery { get; set; }

        [DisplayName("Gallery Thumbnail Image")]
        public virtual string ThumbnailImage { get; set; }
    }
}