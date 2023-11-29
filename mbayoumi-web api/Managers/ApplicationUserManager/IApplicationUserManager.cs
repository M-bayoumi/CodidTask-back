
using mbayoumi_web_api.Data.Models;
using mbayoumi_web_api.Dtos;

namespace mbayoumi_web_api.Managers.ApplicationUserManager
{
    public interface IApplicationUserManager
    {
        Task<Response> RegisterAsync(RegisterDto registerDto);
        Task<Response> LoginAsync(LoginDto loginDto);
    }
}
