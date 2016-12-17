using System.Collections.Generic;

namespace MaterialCMS.Tasks
{
    internal interface ILuceneIndexTask
    {
        IEnumerable<LuceneAction> GetActions();
    }
}