namespace WebShopBLL.Infrastructure
{
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class AuthOptions
    {
        public static string Issuer => "localhost_issuer";
        public static string Audience => "localhost_audience";
        public static string Key => "my_super_secret_key";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
    }
}
