using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using NHibernate;

namespace MaterialCMS.Services.CloneSite
{
    public class SetPageTemplate : CloneWebpagePart<Webpage>
    {
        private readonly ISession _session;

        public SetPageTemplate(ISession session)
        {
            _session = session;
        }

        public override void ClonePart(Webpage @from, Webpage to, SiteCloneContext siteCloneContext)
        {
            if (@from.PageTemplate == null) 
                return;
            to.PageTemplate = siteCloneContext.FindNew<PageTemplate>(@from.PageTemplate.Id);
            _session.Transact(session => session.Update(to));
        }
    }
}