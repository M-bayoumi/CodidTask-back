using mbayoumi_web_api.Data.Models;
using mbayoumi_web_api.Dtos;
using mbayoumi_web_api.Managers.ApplicationUserManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mbayoumi_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IApplicationUserManager _applicationUserManager;

        public ApplicationUsersController(IApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.RegisterAsync(registerDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.LoginAsync(loginDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(loginDto);

        }
    }
}
