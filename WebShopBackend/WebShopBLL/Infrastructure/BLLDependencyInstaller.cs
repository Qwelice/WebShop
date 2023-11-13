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
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
        }
    }
}
