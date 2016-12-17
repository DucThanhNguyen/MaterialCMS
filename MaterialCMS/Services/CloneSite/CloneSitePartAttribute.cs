using System;

namespace MaterialCMS.Services.CloneSite
{
    public class CloneSitePartAttribute : Attribute
    {
        public int Order { get; set; }
        public string Name { get; set; }

        public CloneSitePartAttribute(int order)
        {
            Order = order;
        }
    }
}