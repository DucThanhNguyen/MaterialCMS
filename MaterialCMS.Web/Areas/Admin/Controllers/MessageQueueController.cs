using System.Web.Mvc;
using MaterialCMS.Entities.Messaging;
using MaterialCMS.Models;
using MaterialCMS.Services;
using MaterialCMS.Web.Areas.Admin.Services;
using MaterialCMS.Website.Controllers;

namespace MaterialCMS.Web.Areas.Admin.Controllers
{
    public class MessageQueueController : MaterialCMSAdminController
    {
        private readonly IMessageQueueAdminService _messageQueueAdminService;

        public MessageQueueController(IMessageQueueAdminService messageQueueAdminService)
        {
            _messageQueueAdminService = messageQueueAdminService;
        }

        public ViewResult Index(MessageQueueQuery searchQuery)
        {
            ViewData["data"] = _messageQueueAdminService.GetMessages(searchQuery);
            return View(searchQuery);
        }

        public ActionResult Show(QueuedMessage queuedMessage)
        {
            return View(queuedMessage);
        }

        public ContentResult GetBody(int id)
        {
            QueuedMessage queuedMessage = _messageQueueAdminService.GetMessageBody(id);
            return Content(queuedMessage.Body);
        }
    }
}