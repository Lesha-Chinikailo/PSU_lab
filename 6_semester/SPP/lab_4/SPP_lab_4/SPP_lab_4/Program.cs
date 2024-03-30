using SPP_lab_4.hub;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapHub<MyHub>("/my");

app.Run();
