using System.Collections.Generic;
using MaterialCMS.Services;

namespace MaterialCMS.Web.Apps.Articles.Services
{
    public class ArticlesScriptList : IAppScriptList
    {
        public IEnumerable<string> UIScripts
        {
            get { yield break; }
        }

        public IEnumerable<string> AdminScripts
        {
            get { yield return "~/Apps/Articles/Areas/Admin/Content/Scripts/articles.js"; }
        }
    }
}