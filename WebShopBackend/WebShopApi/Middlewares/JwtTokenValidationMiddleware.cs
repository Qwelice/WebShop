using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebShopBLL.Services.Interfaces;

namespace WebShopApi.Middlewares
{
    public class JwtTokenValidationMiddleware
    {
        private RequestDelegate _next;
        private ITokenService _tokenService;
        private IUserService _userService;

        public JwtTokenValidationMiddleware(RequestDelegate next, ITokenService tokenService, IUserService userService)
        {
            _next = next;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tokenString = context.Request.Cookies["_admXklSvVr0v"];
            var refreshTokenString = context.Request.Cookies["_usRtF0UaT"];
            if (!string.IsNullOrEmpty(tokenString) && !_tokenService.ValidateToken(tokenString))
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadToken(tokenString) as JwtSecurityToken;
                var email = token!.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
                if (!string.IsNullOrEmpty(email))
                {
                    var user = await _userService.GetUserByEmailAsync(email);
                    if(user.RefreshToken != null && user.RefreshToken == refreshTokenString && user.RefreshTokenExpiryTime < DateTime.UtcNow) 
                    {
                        var newAccessToken = _tokenService.GenerateAccessToken(user);
                        var newRefreshToken = _tokenService.GenerateRefreshToken(user);
                        context.Response.Cookies.Append("_admXklSvVr0v", newAccessToken, new CookieOptions
                        {
                            SameSite = SameSiteMode.Strict,
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromMinutes(60)
                        });
                        context.Response.Cookies.Append("_usRtF0UaT", newRefreshToken, new CookieOptions
                        {
                            SameSite = SameSiteMode.Strict,
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromDays(30)
                        });
                        user.RefreshToken = newRefreshToken;
                        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(30);
                        await _userService.UpdateUserAsync(user);
                    }
                }
            }
            await _next(context);
        }
    }
}
