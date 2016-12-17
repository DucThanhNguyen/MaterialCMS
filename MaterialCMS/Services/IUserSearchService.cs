using System.Collections.Generic;
using System.Web.Mvc;
using MaterialCMS.Entities.People;
using MaterialCMS.Models;
using MaterialCMS.Paging;

namespace MaterialCMS.Services
{
    public interface IUserSearchService
    {
        List<SelectListItem> GetAllRoleOptions();
        IPagedList<User> GetUsersPaged(UserSearchQuery searchQuery);
    }
}