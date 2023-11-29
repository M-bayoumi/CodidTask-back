using mbayoumi_web_api.Data.Context;
using mbayoumi_web_api.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace mbayoumi_web_api.Repos.ImageRepo
{
    public class ImageRepo:IImageRepo
    {
        private readonly AppDbContext _appDbContext;
        public ImageRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Image image)
        {
            await _appDbContext.Set<Image>().AddAsync(image);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
