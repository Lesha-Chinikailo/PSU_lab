using System.Net;
using System.Net.WebSockets;
using System.Text;
using WS_Server;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:6969");
var app = builder.Build();
app.UseWebSockets();
var connections = new List<WebSocket>();

string str = "реклама";

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        connections.Add(ws);

        while (true)
        {
            var message = str;
            if (ws.State == WebSocketState.Open)
            {
                await Broadcast(message);
            }
            else if (ws.State == WebSocketState.Closed || ws.State == WebSocketState.Aborted)
                break;
            Thread.Sleep(new Random().Next(1500, 3500));
        }
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});

async Task Broadcast(string message)
{
    var bytes = Encoding.UTF8.GetBytes(message);
    foreach (var soket in connections)
    {
        if (soket.State == WebSocketState.Open)
        {
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
            await soket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}

await app.RunAsync();
