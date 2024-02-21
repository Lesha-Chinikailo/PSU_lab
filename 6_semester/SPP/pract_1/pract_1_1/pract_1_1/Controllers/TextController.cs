using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace pract_1_1.Controllers
{
    [ApiController]
    [Route("/text")]
    public class TextController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string GetText() 
        {
            string text = "hello world! from GetText()";

            //List<string> text = new List<string>();
            //text.Add("hello");
            //text.Add("world");
            //text.Add("!");
            //text.Add("from");
            //text.Add("GetText()");
            return text;
        }
    }
}
