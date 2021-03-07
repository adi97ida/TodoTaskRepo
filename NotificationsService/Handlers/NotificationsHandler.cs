using ApiGateway.Models;
using NotificationsService.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotificationsService.Handlers
{
    public class NotificationsHandler : INotificationsHandler
    {
        static private readonly HttpClient client = new HttpClient();
        public async Task<bool> DoSendNotifications(Notification notification)
        {
            string requestString = $"https://api.suresms.com/Script/SendSMS.aspx?login=NA&password=BD6naZFc&to={notification.PhoneNo}&Text={notification.Content}";
            var resp = await client.GetAsync(requestString);
            Log.Information($"Requested an SMS notification, response code was: {resp.StatusCode}");
            return resp.IsSuccessStatusCode;
        }
    }
}
