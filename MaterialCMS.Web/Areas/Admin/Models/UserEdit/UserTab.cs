using System.Web.Mvc;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Web.Areas.Admin.Models.UserEdit
{
    public abstract class UserTab : UserTabBase
    {
        public abstract string TabHtmlId { get; }
        public abstract void RenderTabPane(HtmlHelper<User> html, User user);
    }
}