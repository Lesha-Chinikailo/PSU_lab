using SPP_1_Empty;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new List<User>()
{
    new User{ Id = 0.ToString(), Name = "Lesha", Age = 20},
    new User{ Id = 1.ToString(), Name = "Pasha", Age = 25},
    new User{ Id = 2.ToString(), Name = "Masha", Age = 15},
};

app.MapGet("", () => "Hello World!");

app.MapGet("api/users", () => users);

app.MapGet("api/users/{id}", (string id) =>
{
    User? user = users.FirstOrDefault(u => u.Id == id);

    if(user == null) return Results.NotFound(new {message = "user is not found" });

    return Results.Json(user);
});
app.Run();
