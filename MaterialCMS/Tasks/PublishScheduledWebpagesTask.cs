using System.Linq;
using MaterialCMS.DbConfiguration;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using MaterialCMS.Services.Notifications;
using MaterialCMS.Website;
using NHibernate;

namespace MaterialCMS.Tasks
{
    public class PublishScheduledWebpagesTask : SchedulableTask
    {
        private readonly ISession _session;

        public PublishScheduledWebpagesTask(ISession session)
        {
            _session = session;
        }

        public override int Priority
        {
            get { return 0; }
        }

        protected override void OnExecute()
        {
            using (new SiteFilterDisabler(_session))
            {
                var now = CurrentRequestData.Now;
                var due = _session.QueryOver<Webpage>().Where(x => !x.Published && x.PublishOn <= now).List();
                if (!due.Any())
                    return;
                using (new NotificationDisabler())
                {
                    _session.Transact(session =>
                    {
                        foreach (var webpage in due)
                        {
                            webpage.Published = true;
                            session.Update(webpage);
                        }
                    });
                }
            }
        }
    }
}