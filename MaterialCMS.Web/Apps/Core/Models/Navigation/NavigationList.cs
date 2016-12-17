using System.Collections.Generic;

namespace MaterialCMS.Web.Apps.Core.Models.Navigation
{
    public class NavigationList : List<NavigationRecord>
    {
        public NavigationList(IEnumerable<NavigationRecord> list)
        {
            AddRange(list);
        }
    }
}