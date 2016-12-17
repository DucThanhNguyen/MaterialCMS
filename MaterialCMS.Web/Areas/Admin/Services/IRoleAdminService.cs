using System.Collections.Generic;
using MaterialCMS.Entities.People;
using MaterialCMS.Models;
using MaterialCMS.Web.Areas.Admin.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IRoleAdminService
    {
        AddRoleResult AddRole(UserRole model);
        void SaveRole(UserRole role);
        void DeleteRole(UserRole role);
        IEnumerable<UserRole> GetAllRoles();
        IEnumerable<AutoCompleteResult> Search(string term);
        string GetRolesForPermissions();
    }
}