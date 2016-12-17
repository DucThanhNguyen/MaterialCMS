using System.Collections.Generic;
using MaterialCMS.Web.Apps.Core.Models.Navigation;
using MaterialCMS.Web.Apps.Core.Widgets;

namespace MaterialCMS.Web.Apps.Core.Models
{
    public class CurrentPageSubNavigationModel
    {
        public List<NavigationRecord> NavigationList { get; set; }
        public CurrentPageSubNavigation Model { get; set; }
    }
}