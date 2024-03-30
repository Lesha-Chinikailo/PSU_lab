var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getMessage", async (content) =>
{
    content.Response.ContentType = "text/html; charset=utf-8";
    await content.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();
