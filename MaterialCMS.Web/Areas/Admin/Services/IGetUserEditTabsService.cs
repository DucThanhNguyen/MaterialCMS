using System.Collections.Generic;
using MaterialCMS.Entities.People;
using MaterialCMS.Web.Areas.Admin.Models.UserEdit;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IGetUserEditTabsService
    {
        List<UserTabBase> GetEditTabs(User user);
    }
}