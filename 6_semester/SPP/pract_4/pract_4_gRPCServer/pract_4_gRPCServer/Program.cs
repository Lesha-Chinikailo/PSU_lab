using pract_4_gRPCServer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGrpcService<MessengerService>();
app.MapGet("/", () => "Hello World!");

app.Run();
