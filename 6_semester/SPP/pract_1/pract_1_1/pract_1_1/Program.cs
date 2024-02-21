var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseStaticFiles();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("wwwroot/index.html");
//});

app.Run();
