using System.Globalization;
using MaterialCMS.Entities.People;

namespace MaterialCMS.Services.Resources
{
    public interface IGetUserCultureInfo
    {
        CultureInfo Get(User user);
        string GetInfoString(User user);
    }
}