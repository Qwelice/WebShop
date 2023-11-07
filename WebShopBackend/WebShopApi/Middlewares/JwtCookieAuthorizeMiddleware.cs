namespace WebShopApi.Middlewares
{
    public class JwtCookieAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCookieAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies["_admXklSvVr0v"];
            if(!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Add("Authorization", "Bearer " + token);
            }
            await _next(context);
        }
    }
}
