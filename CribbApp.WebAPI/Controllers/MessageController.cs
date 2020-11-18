using CribbApp.Models.MessageModels;
using CribbApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CribbApp.WebAPI.Controllers
{
    public class MessageController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MessageService messageService = CreateMessageService();
            var messages = messageService.GetMessages();
            return Ok(messages);
        }

        public IHttpActionResult Get(int messageId)
        {
            MessageService messageService = CreateMessageService();
            var message = messageService.GetMessageById(messageId);
            return Ok(message);
        }

        public IHttpActionResult Post(MessageCreate message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMessageService();

            if (!service.CreateMessage(message))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Put(MessageEdit message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMessageService();

            if (!service.UpdateMessage(message))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int messageId)
        {
            var service = CreateMessageService();

            if (!service.DeleteMessage(messageId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var messageService = new MessageService(userId);
            return messageService;
        } 
    }
}
