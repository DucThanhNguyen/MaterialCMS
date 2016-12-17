using System.Collections.Generic;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public interface ILocalisedScripts
    {
        IEnumerable<string> Files { get; }
    }
}