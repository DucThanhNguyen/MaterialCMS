using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Models;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ITagAdminService
    {
        IEnumerable<AutoCompleteResult> Search(string term);
        IEnumerable<Tag> GetTags(Document document);
    }
}