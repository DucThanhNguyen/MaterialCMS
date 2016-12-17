using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Paging;

namespace MaterialCMS.Models
{
    public class FilesPagedResult : StaticPagedList<MediaFile>
    {
        public int? CategoryId { get; set; }

        public bool ImagesOnly { get; set; }

        public FilesPagedResult(IEnumerable<MediaFile> subset, IPagedList metaData, int? categoryId, bool imagesOnly)
            : base(subset, metaData)
        {
            CategoryId = categoryId;
            ImagesOnly = imagesOnly;
        }
    }
}