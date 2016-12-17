using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Layout;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ILayoutAreaAdminService
    {
        LayoutArea GetArea(Layout layout, string name);
        void SaveArea(LayoutArea layoutArea);
        LayoutArea GetArea(int layoutAreaId);
        void DeleteArea(LayoutArea area);
        void SetWidgetOrders(PageWidgetSortModel pageWidgetSortModel);
        void SetWidgetForPageOrders(PageWidgetSortModel pageWidgetSortModel);
        void ResetSorting(LayoutArea area, int pageId);
        PageWidgetSortModel GetSortModel(LayoutArea area, int pageId);

        IEnumerable<SelectListItem> GetValidParents(Layout doc);
        void Set(Layout doc, int? parentId);
    }
}