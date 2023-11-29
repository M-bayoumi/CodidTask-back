using mbayoumi_web_api.Data.Models;
using mbayoumi_web_api.Dtos;
using mbayoumi_web_api.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mbayoumi_web_api.Managers.ApplicationUserManager
{
    public class ApplicationUserManager:IApplicationUserManager
    {
        private readonly IApplicationUserRepo _applicationUserRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public ApplicationUserManager(IApplicationUserRepo applicationUserRepo, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _applicationUserRepo = applicationUserRepo;
            _configuration = configuration;
        }


        #region RegisterAsync
        public async Task<Response> RegisterAsync(RegisterDto registerDto)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };

            IEnumerable<IdentityError> errors = await _applicationUserRepo.AddAsync(applicationUser, registerDto.Password);
            if (!errors.Any())
            {

                return new Response { Success = true, Data = null, Messages = $"User has been Added" };
            }
            return new Response { Success = false, Data = null, Messages = $"User failed to Added" };
        }
        #endregion


        #region LoginAsync
        public async Task<Response> LoginAsync(LoginDto loginDto)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is not null)
            {
                bool found = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (found)
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, user.UserName!));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));



                    SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));

                    SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken jwtSecurityToken =
                        new JwtSecurityToken
                        (
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: claims,
                        expires: loginDto.RememberMe ? DateTime.Now.AddDays(15) : DateTime.Now.AddHours(1),
                        signingCredentials: signingCred
                        );

                    return new Response { Success =  true, Data =  new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    },
                        Messages = $"{user.Email} is authorized" };

                }
            }
            return new Response { Success = false,Data = null, Messages = $"Email or password is not valid" };
        }
        #endregion

    }
}
