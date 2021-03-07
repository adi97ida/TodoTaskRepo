using ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsService.Interfaces
{
    public interface INotificationsHandler
    {
        public Task<bool> DoSendNotifications(Notification notification);
    }
}
