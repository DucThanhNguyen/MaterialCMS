using System.Collections.Generic;

namespace MaterialCMS.Website
{
    public interface IOnEndRequestExecutor
    {
        void ExecuteTasks(HashSet<EndRequestTask> tasks);
    }
}