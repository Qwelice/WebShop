namespace WebShopBLL.Services
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;

    public class TokenService : ITokenService
    {
        private ITokenConfigurationService _tokenConfig;

        public TokenService(ITokenConfigurationService tokenConfigurationService)
        {
            _tokenConfig = tokenConfigurationService;
        }

        public string CreateToken(UserDTO userDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userDTO.Email)
            };

            foreach (var role in userDTO.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var jwt = new JwtSecurityToken(
                issuer: _tokenConfig.GetIssuer(),
                audience: _tokenConfig.GetAudience(),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(_tokenConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public bool ValidateToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _tokenConfig.GetIssuer(),
                ValidAudience = _tokenConfig.GetAudience(),
                IssuerSigningKey = _tokenConfig.GetSymmetricSecurityKey(),
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
