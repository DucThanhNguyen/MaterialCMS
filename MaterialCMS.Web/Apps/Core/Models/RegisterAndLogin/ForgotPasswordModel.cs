using System.ComponentModel.DataAnnotations;
using MaterialCMS.Helpers.Validation;

namespace MaterialCMS.Web.Apps.Core.Models.RegisterAndLogin
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailValidator]
        public string Email { get; set; }
    }
}