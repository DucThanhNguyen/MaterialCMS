using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Models;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IFileAdminService
    {
        ViewDataUploadFilesResult AddFile(Stream stream, string fileName, string contentType, long contentLength,
            MediaCategory mediaCategory);

        void DeleteFile(MediaFile mediaFile);
        void SaveFile(MediaFile mediaFile);
        bool IsValidFileType(string fileName);
        IPagedList<MediaFile> GetFilesForFolder(MediaCategorySearchModel searchModel);
        List<ImageSortItem> GetFilesToSort(MediaCategory category = null);
        void CreateFolder(MediaCategory category);
        void SetOrders(List<SortItem> items);
        IList<MediaCategory> GetSubFolders(MediaCategorySearchModel searchModel);

        string MoveFolders(IEnumerable<MediaCategory> folders, MediaCategory parent = null);
        void MoveFiles(IEnumerable<MediaFile> files, MediaCategory parent = null);
        void DeleteFilesSoft(IEnumerable<MediaFile> files);
        void DeleteFilesHard(IEnumerable<MediaFile> files);
        void DeleteFoldersSoft(IEnumerable<MediaCategory> folders);
        MediaCategory GetCategory(MediaCategorySearchModel searchModel);
        List<SelectListItem> GetSortByOptions(MediaCategorySearchModel searchModel);
    }
}