var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient();
//builder.Services.AddEndpointsApiExplorer();

var AllowSpecificOrigins = "AllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
          builder =>
          {
              builder.WithOrigins("https://localhost:7103", "https://localhost:7285");
          });
});

var app = builder.Build();

app.UseStaticFiles();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors(AllowSpecificOrigins);

app.MapControllers();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("wwwroot/index.html");
//});

app.Run();
