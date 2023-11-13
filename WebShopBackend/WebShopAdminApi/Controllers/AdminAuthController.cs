namespace WebShopAdminApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebShopApi.Models;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private IUserService _userService;
        private ITokenService _tokenService;

        public AdminAuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO { Email = model.Email, Password = model.Password };
                if(!_userService.IsExists(user))
                {
                    return BadRequest("Такого пользователя не существует");
                }
                if (!_userService.Authenticate(user))
                {
                    return Unauthorized("Неверный пароль");
                }
                var roles = await _userService.GetUserRolesAsync(user);
                if(!roles.Where(r => r.Name == "admin").Any())
                {
                    return Unauthorized("Пользователь не является администратором");
                }
                user.Roles = roles;
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken(user);
                var entity = await _userService.GetUserByEmailAsync(user.Email);
                entity.RefreshToken = refreshToken;
                entity.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(30);

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

                await _userService.UpdateUserAsync(entity);
                return Ok(new { Authenticated = true, Email = user.Email });
            }
            return BadRequest("Некорректные данные");
        }
    }
}
