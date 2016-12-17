using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Website;

namespace MaterialCMS.Events.Documents
{
    public class MarkWebpageAsPublished : IOnUpdating<Webpage>, IOnAdding<Webpage>
    {
        public void Execute(OnUpdatingArgs<Webpage> args)
        {
            var now = CurrentRequestData.Now;
            var webpage = args.Item;
            if (webpage.PublishOn <= now && webpage.Published == false)
            {
                webpage.Published = true;
            }
        }

        public void Execute(OnAddingArgs<Webpage> args)
        {
            var now = CurrentRequestData.Now;
            var webpage = args.Item;
            if (webpage.PublishOn <= now && webpage.Published == false)
            {
                webpage.Published = true;
            }
        }
    }
}