using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Nevus.UI.Hubs
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync(){
        
            await base.OnConnectedAsync();  
        }

        public async Task SendMessage(string sender, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", sender, message);
        }
    }
}
