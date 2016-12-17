using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaterialCMS.Shortcodes;
using MaterialCMS.Website;

namespace MaterialCMS.Helpers
{
    public static class ShortcodeParsingExtensions
    {
        public static IHtmlString ParseShortcodes(this HtmlHelper htmlHelper, string content)
        {
            var shortcodeParsers = MaterialCMSApplication.GetAll<IShortcodeParser>();

            content = shortcodeParsers.Aggregate(content, (current, shortcodeParser) => shortcodeParser.Parse(htmlHelper, current));

            return new HtmlString(content);
        }
    }
}