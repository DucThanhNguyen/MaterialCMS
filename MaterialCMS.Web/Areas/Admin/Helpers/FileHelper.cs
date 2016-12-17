using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Helpers
{
    public static class FileHelper
    {
        public static ViewDataUploadFilesResult GetUploadFilesResult(this MediaFile mediaFile)
        {
            return new ViewDataUploadFilesResult(mediaFile);
        }
    }
}
