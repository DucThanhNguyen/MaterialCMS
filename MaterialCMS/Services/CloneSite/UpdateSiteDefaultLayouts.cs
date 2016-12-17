using System.Linq;
using MaterialCMS.Entities.Documents.Layout;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Settings;
using NHibernate;

namespace MaterialCMS.Services.CloneSite
{
    [CloneSitePart(-65)]
    public class UpdateSiteDefaultLayouts : ICloneSiteParts
    {
        private readonly ISession _session;

        public UpdateSiteDefaultLayouts(ISession session)
        {
            _session = session;
        }

        public void Clone(Site @from, Site to, SiteCloneContext siteCloneContext)
        {
            var toProvider = new SqlConfigurationProvider(_session, @to);
            var pageDefaultsSettings = toProvider.GetSiteSettings<PageDefaultsSettings>();

            var keys = pageDefaultsSettings.Layouts.Keys.ToList();
            foreach (var key in keys.Where(key => pageDefaultsSettings.Layouts[key].HasValue))
            {
                var layout = siteCloneContext.FindNew<Layout>(pageDefaultsSettings.Layouts[key].Value);
                if (layout != null)
                    pageDefaultsSettings.Layouts[key] = layout.Id;
            }

            toProvider.SaveSettings(pageDefaultsSettings);
        }
    }
}