using System.Threading.Tasks;
using MaterialCMS.Settings;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface IThirdPartyAuthSettingsAdminService
    {
        ThirdPartyAuthSettings GetSettings();
        void SaveSettings(ThirdPartyAuthSettings thirdPartyAuthSettings);
    }
}