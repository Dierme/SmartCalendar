using System;
using Xunit;
using SignalRChat;
using Microsoft.AspNet.SignalR.Hubs;
using Moq;
using System.Dynamic;

namespace SmartCalendar
{
    public class HubTest
    {
        [Fact]
        public void HubsAreMockableViaDynamic()
        {
            //Arrange
            bool sendCalled = false;
            var hub = new AlarmHub();
            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            hub.Clients = mockClients.Object;
            dynamic all = new ExpandoObject();

            //Act
            all.broadcastMessage = new Action<string, string>((name, message) =>
            {
                sendCalled = true;
            });
            mockClients.Setup(m => m.All).Returns((ExpandoObject)all);
            hub.Send("TestUser", "TestMessage");
            //Assert
            Assert.True(sendCalled);
        }
    }
}
