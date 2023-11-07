namespace WebShopApi.Middlewares
{
    public class JwtTokenValidationMiddleware
    {
        private RequestDelegate _next;

        public JwtTokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

        }
    }
}
