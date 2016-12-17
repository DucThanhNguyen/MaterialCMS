using System.Collections.Generic;

namespace MaterialCMS.Website.Optimization
{
    public interface IStylesheetBundle
    {
        string Url { get; }
        IEnumerable<string> Files { get; }
    }
}