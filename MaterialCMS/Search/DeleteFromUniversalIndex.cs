using MaterialCMS.Entities;
using MaterialCMS.Website;

namespace MaterialCMS.Search
{
    public class DeleteFromUniversalIndex : EndRequestTask<SystemEntity>
    {
        public DeleteFromUniversalIndex(SystemEntity entity)
            : base(entity)
        {
        }
    }
}