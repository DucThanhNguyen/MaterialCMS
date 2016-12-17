using System.Collections.Generic;
using MaterialCMS.Entities.Documents;

namespace MaterialCMS.Services
{
    public interface IGetBreadcrumbs
    {
        IEnumerable<Document> Get(int? parent);
    }
}