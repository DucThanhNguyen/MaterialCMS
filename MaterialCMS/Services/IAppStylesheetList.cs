using System.Collections.Generic;

namespace MaterialCMS.Services
{
    public interface IAppStylesheetList
    {
        IEnumerable<string> UIStylesheets { get; }
        IEnumerable<string> AdminStylesheets { get; }
    }
}