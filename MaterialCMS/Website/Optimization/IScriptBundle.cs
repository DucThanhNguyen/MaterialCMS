using System.Collections.Generic;

namespace MaterialCMS.Website.Optimization
{
    public interface IScriptBundle
    {
        string Url { get; }
        IEnumerable<string> Files { get; }
    }
}