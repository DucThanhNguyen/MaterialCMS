using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Models;
using MaterialCMS.Website.Binders;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.ModelBinders
{

    public class MoveFilesModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly IDocumentService _documentService;
        private readonly ISession _session;

        public MoveFilesModelBinder(IKernel kernel, IDocumentService documentService, ISession session)
            : base(kernel)
        {
            _documentService = documentService;
            _session = session;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var folderId =
                GetValueFromContext(controllerContext, "folderId");
            var files =
                GetValueFromContext(controllerContext, "files");
            var folders =
                GetValueFromContext(controllerContext, "folders");

            var model = new MoveFilesAndFoldersModel();

            if (folderId != "")
            {
                model.Folder = _documentService.GetDocument<MediaCategory>(Convert.ToInt32(folderId));
            }
            if (files != "")
            {
                model.Files = _session.QueryOver<MediaFile>().Where(arg => arg.Id.IsIn(files.Split(',').Select(int.Parse).ToList())).List();
            }
            if (folders != "")
            {
                model.Folders = _session.QueryOver<MediaCategory>().Where(arg => arg.Id.IsIn(folders.Split(',').Select(int.Parse).ToList())).List();
            }
            return model;
        }
    }


    public class DeleteFilesModelBinder : MaterialCMSDefaultModelBinder
    {
        private readonly ISession _session;

        public DeleteFilesModelBinder(IKernel kernel, ISession session)
            : base(kernel)
        {
            _session = session;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var files =
                GetValueFromContext(controllerContext, "files");
            var folders =
                GetValueFromContext(controllerContext, "folders");

            var model = new DeleteFilesAndFoldersModel();
            if (files != "")
            {
                model.Files = _session.QueryOver<MediaFile>().Where(arg => arg.Id.IsIn(files.Split(',').Select(int.Parse).ToList())).List();
            }
            if (folders != "")
            {
                model.Folders = _session.QueryOver<MediaCategory>().Where(arg => arg.Id.IsIn(folders.Split(',').Select(int.Parse).ToList())).List();
            }
            return model;
        }
    }
}