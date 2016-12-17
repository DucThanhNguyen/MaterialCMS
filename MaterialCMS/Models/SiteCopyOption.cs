using System;
using System.ComponentModel;

namespace MaterialCMS.Models
{
    public class SiteCopyOption
    {
        [DisplayName("Action")]
        public Type SiteCopyActionType { get; set; }

        [DisplayName("Copy from")]
        public int SiteId { get; set; }
    }
}