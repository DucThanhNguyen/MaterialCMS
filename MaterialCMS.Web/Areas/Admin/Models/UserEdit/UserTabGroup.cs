using System.Collections.Generic;

namespace MaterialCMS.Web.Areas.Admin.Models.UserEdit
{
    public abstract class UserTabGroup : UserTabBase
    {
        protected UserTabGroup()
        {
            Children = new List<UserTabBase>();
        }

        public List<UserTabBase> Children { get; private set; }

        public void SetChildren(List<UserTabBase> children)
        {
            Children = children;
        }
    }
}