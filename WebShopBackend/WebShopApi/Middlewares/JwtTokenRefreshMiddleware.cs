namespace WebShopApi.Middlewares
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;

    public class JwtTokenRefreshMiddleware
    {
        private RequestDelegate _next;

        public JwtTokenRefreshMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITokenService tokenService, IUserService userService, IConfiguration config)
        {
            var tokenString = context.Request.Cookies["_admXklSvVr0v"];
            var refreshTokenString = context.Request.Cookies["_usRtF0UaT"];

            if (!string.IsNullOrEmpty(refreshTokenString) && (string.IsNullOrEmpty(tokenString) || !tokenService.ValidateToken(tokenString)))
            {
                UserDTO? user = null;

                if (!string.IsNullOrEmpty(tokenString))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadToken(tokenString) as JwtSecurityToken;
                    var email = token?.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
                    if (!string.IsNullOrEmpty(email))
                    {
                        user = userService.GetUserByEmailAsync(email).Result;
                    }
                }
                else
                {
                    user = userService.GetUserByRefreshTokenAsync(refreshTokenString).Result;
                }
                if(user != null)
                {
                    if (user.RefreshToken != null && user.RefreshToken == refreshTokenString && user.RefreshTokenExpiryTime < DateTime.UtcNow)
                    {
                        var newAccessToken = tokenService.GenerateAccessToken(user);
                        var newRefreshToken = tokenService.GenerateRefreshToken(user);
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
                        await userService.UpdateUserAsync(user);
                    }
                }
            }

            await _next(context);
        }
    }
}
