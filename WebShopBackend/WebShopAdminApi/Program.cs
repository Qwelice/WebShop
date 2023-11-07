namespace WebShopApi
{
    using WebShopApi.Middlewares;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.UseMiddleware<JwtCookieAuthorizeMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}