using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodosService.Interfaces;
using DataRepository.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using DataRepository.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TodosService.Handlers
{
    public class NotificationsHandler : INotificationsHandler
    {
        static private readonly HttpClient client = new HttpClient();

        private readonly IModelRepository<TodoList> dbContext;
        public NotificationsHandler(IModelRepository<TodoList> context)
        {
            dbContext = context;
        }

        public async Task<Notification> DoNotifyUser(Notification notification) {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "http://localhost:5001/api/v1/Notifications/SendNotification", notification);
                response.EnsureSuccessStatusCode();
                return notification;
            } catch(HttpRequestException ex)
            {
                // TODO: Log exception
                return null;
            }
        }

        public async Task<string> DoNotifyUsers(string todoListId, string todoItemId)
        {
            List<SubscribedUsers> subscriptions = await dbContext.DB.SubscribedUsers.Include("User").Where(c => c.TodoListId == todoListId).ToListAsync();
            TodoList todoList = await dbContext.DB.TodoLists.FindAsync(todoListId);
            TodoItem todoItem = await dbContext.DB.TodoItems.FindAsync(todoItemId);

            int totalSentNotifications = 0;
            foreach (var subscription in subscriptions)
            {
                Notification tmpNotification = new Notification
                {
                    Content = $"A new entry ({todoItem.Name}) has been added to the {todoList.Name} list.",
                    PhoneNo = subscription.User.PhoneNo,
                };

                var resp = await DoNotifyUser(tmpNotification);
                if(resp != null)
                {
                    dbContext.DB.Notifications.Add(resp);
                    await dbContext.DB.SaveChangesAsync();
                    ++totalSentNotifications;
                }
            }

            return $"Sent a total of {totalSentNotifications} out of {subscriptions.Count()} notifications";
        }
    }
}
