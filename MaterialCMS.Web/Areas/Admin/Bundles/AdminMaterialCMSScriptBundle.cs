using System.Collections.Generic;
using MaterialCMS.Website.Optimization;

namespace MaterialCMS.Web.Areas.Admin.Bundles
{
    public class AdminMaterialCMSScriptBundle : IScriptBundle
    {
        public string Url
        {
            get { return "~/admin/scripts/materialcms"; }
        }

        public IEnumerable<string> Files
        {
            get
            {
                yield return "~/Areas/Admin/Content/Scripts/materialcms/menu.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/stickyTabs.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/admin.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/tagging.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/search.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/batch.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/media-uploader.js";
                yield return "~/Areas/Admin/Content/Scripts/materialcms/materialcms-media-selector.js";
            }
        }
    }
}