using System;
using MaterialCMS.Entities.Documents.Layout;
using MaterialCMS.Entities.Documents.Web;

namespace MaterialCMS.Events
{
    public class OnDeletingLayout : IOnDeleting<Layout>
    {
        public void Execute(OnDeletingArgs<Layout> args)
        {
            Layout layout = args.Item;
            if (layout == null) return;
            foreach (PageTemplate pageTemplate in layout.PageTemplates)
            {
                pageTemplate.Layout = null;
            }
            layout.PageTemplates.Clear();
        }
    }
}