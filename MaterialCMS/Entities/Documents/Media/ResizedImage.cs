using System.ComponentModel.DataAnnotations;
using MaterialCMS.DbConfiguration.Configuration;

namespace MaterialCMS.Entities.Documents.Media
{
    public class ResizedImage : SiteEntity
    {
        public virtual MediaFile MediaFile { get; set; }
        public virtual Crop Crop { get; set; }
        [StringLength(450), IsDBLength]
        public virtual string Url { get; set; }
    }
}