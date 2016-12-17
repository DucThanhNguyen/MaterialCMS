using System.Collections.Generic;

namespace MaterialCMS.Services
{
    public interface IAppScriptList
    {
        IEnumerable<string> UIScripts { get; }
        IEnumerable<string> AdminScripts { get; }
    }
}