using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Paging;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IMediaSelectorService
    {
        IPagedList<MediaFile> Search(MediaSelectorSearchQuery searchQuery);
        List<SelectListItem> GetCategories();
        SelectedItemInfo GetFileInfo(string value);
        string GetAlt(string url);
        string GetDescription(string url);
        bool UpdateAlt(UpdateMediaParams updateMediaParams);
        bool UpdateDescription(UpdateMediaParams updateMediaParams);
    }
}