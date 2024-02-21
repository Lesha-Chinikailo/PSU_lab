using System.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/getFile", async (context) =>
{
    User user = new User
    {
        Age = 20,
        Name = "Lesha"
    };
    var userjson = JsonSerializer.Serialize(user);
    string filename = "myFile.json";
    File.WriteAllText(filename, userjson);
    //await context.Response.WriteAsJsonAsync(user);
    await context.Response.SendFileAsync(filename);

});

app.Run();

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}