using MaterialCMS.Website;

namespace MaterialCMS.Installation
{
    public class InitializeIndexes : EndRequestTask<int>
    {
        public InitializeIndexes() : base(0)
        {
        }
    }
}