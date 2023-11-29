using mbayoumi_web_api.Data.Models;

namespace mbayoumi_web_api.Managers.ImageManager
{
    public interface IImageManager
    {
        Task<Response> UploadAsync(byte[] imageBytes);
    }
}
