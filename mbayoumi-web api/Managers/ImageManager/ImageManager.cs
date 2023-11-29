using mbayoumi_web_api.Data.Models;
using mbayoumi_web_api.Repos;
using mbayoumi_web_api.Repos.ImageRepo;
using Microsoft.AspNetCore.Identity;

namespace mbayoumi_web_api.Managers.ImageManager
{
    public class ImageManager:IImageManager
    {
      
        private readonly IImageRepo _imageRepo;

        public ImageManager(IImageRepo image)
        {
            _imageRepo = image;
        }

        #region UploadAsync
        public async Task<Response> UploadAsync(byte[] imageBytes)
        {
            Image image = new Image
            {
                ImageBytes = imageBytes
            };
            await _imageRepo.AddAsync(image);
            bool result = await _imageRepo.SaveChangesAsync() > 0;
            if (result)
            {
                return new Response {Success= true,Data= null,Messages= "The Image has been uploaded successfully" };
            }
            return new Response { Success = false, Data = null, Messages = "Failed to upload Image" };
        }
        #endregion



    }
}
