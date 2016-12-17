using MaterialCMS.Entities;
using MaterialCMS.Website;

namespace MaterialCMS.Search
{
    public class UpdateUniversalIndex : EndRequestTask<SystemEntity>
    {
        public UpdateUniversalIndex(SystemEntity entity)
            : base(entity)
        {

        }
    }
}