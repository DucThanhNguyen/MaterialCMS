using MaterialCMS.Entities.Documents.Layout;

namespace MaterialCMS.Events
{
    public class OnDeletingLayoutArea : IOnDeleting<LayoutArea>
    {
        public void Execute(OnDeletingArgs<LayoutArea> args)
        {
            var area = args.Item;
            if (area.Layout != null)
            {
                area.Layout.LayoutAreas.Remove(area); //required to clear cache
                args.Session.SaveOrUpdate(area.Layout);
            }
        }
    }
}