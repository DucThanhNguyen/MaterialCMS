using System.Collections.Generic;
using MaterialCMS.Entities.Multisite;
using MaterialCMS.Models;

namespace MaterialCMS.Services.CloneSite
{
    public interface ICloneSiteService
    {
        void CloneData(Site site, List<SiteCopyOption> options);
    }
}