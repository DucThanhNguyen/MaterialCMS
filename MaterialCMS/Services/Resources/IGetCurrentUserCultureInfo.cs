using System.Globalization;

namespace MaterialCMS.Services.Resources
{
    public interface IGetCurrentUserCultureInfo
    {
        CultureInfo Get();
        string GetInfoString();
    }
}