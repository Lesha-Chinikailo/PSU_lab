using SPP_lab_4.hub;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<MyHub>("/my");


//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("wwwroot/index.html");
//});

app.Run();
