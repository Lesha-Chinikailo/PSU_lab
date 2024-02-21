using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace pract_1_1.Controllers
{
    [ApiController]
    [Route("json")]
    public class FileJsonController : Controller
    {
        [HttpGet(Name = "GetFileJson")]
        public async Task<IActionResult> GetFileJson() 
        {
            User user = new User("Lesha", 20);

            string jsonFileName = "User.json";
            string jsonString = JsonSerializer.Serialize(user);

            System.IO.File.WriteAllText(jsonFileName, jsonString);

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(jsonString);
            writer.Flush();
            memoryStream.Position = 0;
            return File(memoryStream, "application/json", jsonFileName);
        }
    }
    class User
    {
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
