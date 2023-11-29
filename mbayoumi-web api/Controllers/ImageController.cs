using mbayoumi_web_api.Data.Models;
using mbayoumi_web_api.Managers.ApplicationUserManager;
using mbayoumi_web_api.Managers.ImageManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mbayoumi_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageManager _imageManager;

        public ImageController(IImageManager imageManager)
        {
            _imageManager = imageManager;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                var image = Request.Form.Files[0];

                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();


                   
                    Response response = await _imageManager.UploadAsync(imageBytes);

                    if (response.Success)
                    {
                        return Ok(response);
                    }

                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
