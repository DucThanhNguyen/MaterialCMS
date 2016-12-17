using System.ComponentModel;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Models
{
    public class UserSearchQuery
    {
        public UserSearchQuery()
        {
            Page = 1;
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? UserRoleId { get; set; }
        public int Page { get; set; }
    }
}