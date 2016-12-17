using System;
using System.Collections.Generic;

namespace MaterialCMS.Services.Sitemaps
{
    public interface ISitemapDataSource
    {
        IEnumerable<SitemapData> GetAdditionalData();
        IEnumerable<Type> TypesToRemove { get; }
    }
}