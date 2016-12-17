using MaterialCMS.Settings;

namespace MaterialCMS.ACL
{
    public class ACLSettings : SiteSettingsBase
    {
        public override bool RenderInSettings
        {
            get { return false; }
        }

        public bool ACLEnabled { get; set; }
    }
}