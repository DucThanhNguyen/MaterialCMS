using System.Collections;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Installation;
using MaterialCMS.Web.Apps.Core.Services.Installation;
using MaterialCMS.Web.Apps.Core.Widgets;
using MaterialCMS.Web.Areas.Admin.Services;

namespace MaterialCMS.Web.Apps.Core
{
    public class CoreAppInstallation : IOnInstallation
    {
        private readonly ISetupCoreLayouts _setupCoreLayouts;
        private readonly ISetupCoreWebpages _setupCoreWebpages;
        private readonly ISetupCoreMedia _setupCoreMedia;

        public CoreAppInstallation(ISetupCoreLayouts setupCoreLayouts, ISetupCoreWebpages setupCoreWebpages, ISetupCoreMedia setupCoreMedia)
        {
            _setupCoreLayouts = setupCoreLayouts;
            _setupCoreWebpages = setupCoreWebpages;
            _setupCoreMedia = setupCoreMedia;
        }

        public int Priority
        {
            get { return -1; }
        }

        public void Install(InstallModel model)
        {
            //settings
            _setupCoreLayouts.Setup();
            _setupCoreWebpages.Setup();
            _setupCoreMedia.Setup();
        }
    }
}