using System.Web.Mvc;

namespace MaterialCMS.Shortcodes
{
    public interface IShortcodeParser
    {
        string Parse(HtmlHelper htmlHelper, string current);
    }
}