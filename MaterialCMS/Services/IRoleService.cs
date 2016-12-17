using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.People;
using MaterialCMS.Models;

namespace MaterialCMS.Services
{
    public interface IRoleService
    {
        void SaveRole(UserRole role);
        IEnumerable<UserRole> GetAllRoles();
        UserRole GetRoleByName(string name);
        void DeleteRole(UserRole role);
        bool IsOnlyAdmin(User user);
        IEnumerable<AutoCompleteResult> Search(string term);
        UserRole GetRole(int id);
    }
}