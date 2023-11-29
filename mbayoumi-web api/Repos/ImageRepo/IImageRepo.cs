using mbayoumi_web_api.Data.Models;

namespace mbayoumi_web_api.Repos.ImageRepo
{
    public interface IImageRepo
    {
        Task AddAsync(Image image);
        Task<int> SaveChangesAsync();
    }
}
