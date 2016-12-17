using MaterialCMS.Website;

namespace MaterialCMS.Services
{
    public class ApplicationRestart : EndRequestTask<int>
    {
        public ApplicationRestart()
            : base(0)
        {
        }
    }
}