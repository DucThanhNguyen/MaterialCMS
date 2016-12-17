using MaterialCMS.Website;

namespace MaterialCMS.Search
{
    [EndRequestExecutionPriority(1)]
    public class AddUniversalSearchTaskInfo : EndRequestTask<UniversalSearchIndexData>
    {
        public AddUniversalSearchTaskInfo(UniversalSearchIndexData data)
            : base(data)
        {
        }
    }
}