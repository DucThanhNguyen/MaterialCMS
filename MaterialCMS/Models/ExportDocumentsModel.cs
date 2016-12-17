using System.ComponentModel.DataAnnotations;
using MaterialCMS.Helpers.Validation;

namespace MaterialCMS.Models
{
    public class ExportDocumentsModel
    {
        [Required, EmailValidator]
        public string Email { get; set; }
    }
}