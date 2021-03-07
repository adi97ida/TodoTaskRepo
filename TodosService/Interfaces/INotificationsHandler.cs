using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosService.Interfaces
{
    public interface INotificationsHandler
    {
        public Task<Notification> DoNotifyUser(Notification notification);
        public Task<string> DoNotifyUsers(string todoListId, string todoItemId);

    }
}
