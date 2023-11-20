namespace WebShopApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebShopApi.Models;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;
    using WebShopDAL.Enums;

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

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(_userService.IsExists(new UserDTO { Email = model.Email }))
                {
                    return BadRequest("Пользователь с таким E-mail уже существует");
                }
                var user = new UserDTO { Email = model.Email, Password = model.Password };
                user.Roles.Add(new RoleDTO(RoleTypes.User));
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
                return Ok(new { Authenticated = true, Email = user.Email });
            }
            return BadRequest("Некорректные данные");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new UserDTO { Email = model.Email, Password = model.Password };
                if (!_userService.IsExists(user))
                {
                    return BadRequest("Такого пользователя не существует");
                }
                if(!_userService.Authenticate(user))
                {
                    return Unauthorized("Некорректные данные");
                }
                var roles = await _userService.GetUserRolesAsync(user);
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
