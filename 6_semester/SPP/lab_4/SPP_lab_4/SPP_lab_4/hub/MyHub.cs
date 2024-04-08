using Microsoft.AspNetCore.SignalR;

namespace SPP_lab_4.hub
{
    public class MyHub : Hub
    {
        public async Task Send()
        {
            await Clients.All.SendAsync("Recieve", "(hello from hub)");
        }
    }
}
