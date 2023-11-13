namespace WebShopBLL.Infrastructure
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using WebShopBLL.Services;
    using WebShopBLL.Services.Interfaces;
    using WebShopDAL.Infrastructure;

    public static class BLLDependencyInstaller
    {
        public static void AddBLL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDAL();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ITokenConfigurationService, TokenConfigurationService>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped<IWebShopService, WebShopService>();
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
        }
    }
}
