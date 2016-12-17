using System;
using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Metadata;
using MaterialCMS.Web.Apps.Galleries.Pages;

namespace MaterialCMS.Web.Apps.Galleries.Metadata
{
    public class GalleryMetaData : DocumentMetadataMap<Gallery>
    {
        public override string IconClass
        {
            get
            {
                return "glyphicon glyphicon-picture";
            }
        }

        public override IEnumerable<Type> ChildrenList
        {
            get { yield break; }
        }
    }
}

