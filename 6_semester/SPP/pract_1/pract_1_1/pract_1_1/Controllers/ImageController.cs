using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace pract_1_1.Controllers
{
    [ApiController]
    [Route("/image")]
    [EnableCors("AllowSpecificOrigins")]
    public class ImageController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            string imagePath = "wwwroot\\images\\image_3.jpg";

            if(!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }
            var image = System.IO.File.OpenRead(imagePath);
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

            string contentType = "image/jpg";

            return File(imageBytes, contentType);
        }
    }
}
