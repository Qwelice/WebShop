namespace WebShopApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebShopApi.Models;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if(ModelState.IsValid && !_userService.IsExists(new WebShopBLL.DTO.UserDTO { Email = model.Email }))
            {
                var user = new UserDTO { Email = model.Email, Password = model.Password };
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken(user);
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(30);
                Response.Cookies.Append("_admXklSvVr0v", accessToken, new CookieOptions
                {
                    SameSite = SameSiteMode.Strict,
                    HttpOnly = true,
                    Secure = true,
                    MaxAge = TimeSpan.FromMinutes(60)
                });
                Response.Cookies.Append("_usRtF0UaT", refreshToken, new CookieOptions
                {
                    SameSite = SameSiteMode.Strict,
                    HttpOnly = true,
                    Secure = true,
                    MaxAge = TimeSpan.FromDays(30)
                });
                await _userService.SaveUserAsync(user);
            }
            return BadRequest("Некорректные данные");
        }
    }
}
