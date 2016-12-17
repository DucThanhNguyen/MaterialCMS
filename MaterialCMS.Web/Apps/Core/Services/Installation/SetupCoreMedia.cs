using System.IO;
using System.Web;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Helpers;
using MaterialCMS.Services;
using NHibernate;

namespace MaterialCMS.Web.Apps.Core.Services.Installation
{
    public class SetupCoreMedia : ISetupCoreMedia
    {
        private readonly ISession _session;
        private readonly IFileService _fileService;

        public SetupCoreMedia(ISession session, IFileService fileService)
        {
            _session = session;
            _fileService = fileService;
        }

        public void Setup()
        {
            _session.Transact(session =>
            {
                var defaultMediaCategory = new MediaCategory
                {
                    Name = "Default",
                    UrlSegment = "default",
                };
                session.Save(defaultMediaCategory);

                string logoPath = HttpContext.Current.Server.MapPath("/Apps/Core/Content/images/logo.png");
                var fileStream = new FileStream(logoPath, FileMode.Open);
                MediaFile dbFile = _fileService.AddFile(fileStream, Path.GetFileName(logoPath), "image/png",
                    fileStream.Length,
                    defaultMediaCategory);
            });
        }
    }
}