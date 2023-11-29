using mbayoumi_web_api.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace mbayoumi_web_api.Repos
{
    public interface IApplicationUserRepo
    {
        Task<IEnumerable<IdentityError>> AddAsync(ApplicationUser applicationUser, string password);
    }
}
