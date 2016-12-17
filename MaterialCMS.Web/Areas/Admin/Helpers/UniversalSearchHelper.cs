using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Helpers;
using MaterialCMS.Search;

namespace MaterialCMS.Web.Areas.Admin.Helpers
{
    public static class UniversalSearchHelper
    {
        public static List<SelectListItem> GetOptions()
        {
            return TypeHelper.GetAllConcreteTypesAssignableFrom(typeof (GetUniversalSearchItemBase<>))
                .Select(
                    x =>
                        x.GetBaseTypes()
                            .First(y => y.GetGenericTypeDefinition() == typeof (GetUniversalSearchItemBase<>))
                            .GetGenericArguments()[0])
                .OrderBy(x => x.Name)
                .BuildSelectItemList(x => x.Name.BreakUpString(), x => x.FullName, emptyItemText: "All");
        }
    }
}