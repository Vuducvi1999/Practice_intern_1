using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Products_pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        // GET Image
        [HttpGet("{path}")]
        public IActionResult GetImage(string path)
        {
            try
            {
                var provider = new FileExtensionContentTypeProvider();
                string contentType;
                provider.TryGetContentType(path, out contentType);

                byte[] binaryImage = System.IO.File.ReadAllBytes("Upload\\" + path);

                return File(binaryImage, contentType);
            }
            catch { throw; }
        }
    }
}
