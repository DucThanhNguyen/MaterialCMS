using System;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Entities.Widget;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Caching;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class SetCacheExpiryOptions : BaseAssignWidgetAdminViewData<Widget>
    {
        public override void AssignViewData(Widget widget, ViewDataDictionary viewData)
        {
            viewData["cache-expiry-options"] = Enum.GetValues(typeof(CacheExpiryType)).Cast<CacheExpiryType>()
                .BuildSelectItemList(type => type.ToString().BreakUpString(),
                    type => type.ToString(),
                    emptyItem: null);
        }
    }
}