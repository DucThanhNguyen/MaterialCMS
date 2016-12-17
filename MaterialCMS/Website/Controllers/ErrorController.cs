using System;
using System.Web.Mvc;

namespace MaterialCMS.Website.Controllers
{
    public class ErrorController : MaterialCMSUIController
    {
        public ViewResult FileNotFound(Uri url)
        {
            return View(new FileNotFoundModel(url));
        }

        public class FileNotFoundModel 
        {
            public FileNotFoundModel(Uri url)
            {
                MissingUrl = url;
            }

            public Uri MissingUrl { get; private set; }
        }
    }
}