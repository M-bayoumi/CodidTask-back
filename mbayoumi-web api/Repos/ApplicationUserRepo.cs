using mbayoumi_web_api.Data.Context;
using mbayoumi_web_api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace mbayoumi_web_api.Repos
{
    public class ApplicationUserRepo:IApplicationUserRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepo(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        public async Task<IEnumerable<IdentityError>> AddAsync(ApplicationUser applicationUser, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            return result.Errors;
        }
    }
}
