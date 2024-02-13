using Microsoft.AspNetCore.Mvc;

namespace pract_1_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var image = System.IO.File.OpenRead("wwwroot\\images\\image_3.jpg");
            return File(image, "image/jpg");
        }
    }
}
