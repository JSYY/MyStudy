using Abp.Dependency;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.Hubs
{
    public class WebConsoleHub:Hub, ISingletonDependency
    {
        private string _currentConnectionId;
        private readonly string _postResultMethodName = "ResponsePostResult";
        public WebConsoleHub()
        {

        }
        public async Task SendMessage(string method, object messageContext)
        {
            await Clients.All.SendAsync(method, messageContext);
        }

        public async Task SendMessageToOneClient(string method, object messageContext)
        {
            await Clients.Client(_currentConnectionId).SendAsync(method, messageContext);
        }

        public async Task SendPostResult(object messageContext)
        {
            await Clients.Client(_currentConnectionId).SendAsync(_postResultMethodName, messageContext);
        }

        public override Task OnConnectedAsync()
        {
            _ = SendMessage("GetConnectionID", Context.ConnectionId);
            _currentConnectionId = Context.ConnectionId;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
