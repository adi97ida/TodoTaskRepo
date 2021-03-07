using ApiGateway.Models;
using Microsoft.AspNetCore.Mvc;
using NotificationsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGateway.Controllers
{
    [Route("api/Notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsHandler notificationsHandler;
        public NotificationsController(INotificationsHandler notifHandler)
        {
            notificationsHandler = notifHandler;
        }

        // POST: api/Notifications/SendNotification
        [HttpPost("SendNotification")]
        public async Task<ActionResult> SendNotification(Notification notification)
        {

            //TODO: Send the sms
            var res = await notificationsHandler.DoSendNotifications(notification);
            if (res)
            {
                return Ok();
            }
            else return BadRequest();
        }
    }
}
