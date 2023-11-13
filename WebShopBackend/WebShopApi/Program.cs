namespace WebShopApi
{
    using Microsoft.Extensions.DependencyInjection;
    using WebShopApi.Middlewares;
    using WebShopBLL.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddBLL();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.UseMiddleware<JwtTokenRefreshMiddleware>();
            app.UseMiddleware<JwtCookieAuthorizeMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}