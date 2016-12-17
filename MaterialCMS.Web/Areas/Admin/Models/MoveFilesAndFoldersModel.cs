using System.Collections.Generic;
using MaterialCMS.Entities.Documents.Media;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class MoveFilesAndFoldersModel
    {
        public MediaCategory Folder { get; set; }
        public IEnumerable<MediaFile> Files { get; set; }
        public IEnumerable<MediaCategory> Folders { get; set; }
    }
    public class DeleteFilesAndFoldersModel
    {
        public IEnumerable<MediaFile> Files { get; set; }
        public IEnumerable<MediaCategory> Folders { get; set; }
    }
}