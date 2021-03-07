using DataRepository.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TodosService;
using Xunit;

namespace EndpointTests
{
    public class UserRoutesTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserRoutesTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task TestSuccesfullUserPostRoute()
        {
            User tmpUser = new User
            {
                UserName = "TestUsername1",
                Password = "TestPassword1",
                PhoneNo = "+4552717170"
            };

            // Act
            var response = await _client.PostAsJsonAsync("http://localhost:5001/api/v1/Todos/Users", tmpUser);
            response.EnsureSuccessStatusCode();
            var createdUser = await response.Content.ReadAsAsync<User>();
            // Assert
            Assert.Equal(tmpUser.UserName, createdUser.UserName);
            Assert.Equal(tmpUser.Password, createdUser.Password);
            Assert.Equal(tmpUser.PhoneNo, createdUser.PhoneNo);
            Assert.NotEmpty(createdUser.Id);
        }
    }
}
