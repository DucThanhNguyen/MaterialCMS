using System;
using MaterialCMS.Entities;

namespace MaterialCMS.Services.CloneSite
{
    public class SiteCloneContextEntry
    {
        public Type Type { get; set; }
        public int Id { get; set; }

        public SystemEntity NewEntity { get; set; }

        public SystemEntity Original { get; set; }
    }
}