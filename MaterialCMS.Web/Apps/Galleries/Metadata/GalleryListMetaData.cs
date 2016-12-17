using System;
using System.Collections.Generic;
using MaterialCMS.Entities.Documents;
using MaterialCMS.Entities.Documents.Metadata;
using MaterialCMS.Web.Apps.Galleries.Pages;

namespace MaterialCMS.Web.Apps.Galleries.Metadata
{
    public class GalleryListMetaData : DocumentMetadataMap<GalleryList>
    {
        public override string IconClass
        {
            get
            {
                return "glyphicon glyphicon-th";
            }
        }
        public override ChildrenListType ChildrenListType
        {
            get { return ChildrenListType.WhiteList; }
        }

        public override IEnumerable<Type> ChildrenList
        {
            get { yield return typeof(Pages.Gallery); }
        }
    }
}

