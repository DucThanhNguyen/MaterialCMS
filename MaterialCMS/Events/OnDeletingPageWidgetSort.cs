using MaterialCMS.DbConfiguration;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Events
{
    public class OnDeletingPageWidgetSort : IOnDeleting<PageWidgetSort>
    {
        public void Execute(OnDeletingArgs<PageWidgetSort> args)
        {
            var sort = args.Item;
            if (sort == null) return;

            if (sort.LayoutArea.PageWidgetSorts.Contains(sort))
                sort.LayoutArea.PageWidgetSorts.Remove(sort);
            if (sort.Webpage.PageWidgetSorts.Contains(sort))
                sort.Webpage.PageWidgetSorts.Remove(sort);
            if (sort.Widget.PageWidgetSorts.Contains(sort))
                sort.Widget.PageWidgetSorts.Remove(sort);
        }
    }
}