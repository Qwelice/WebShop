namespace WebShopBLL.Services
{
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using WebShopBLL.Services.Interfaces;

    public class TokenConfigurationService : ITokenConfigurationService
    {
        public string GetIssuer()
        {
            return "localhost_issuer";
        }

        public string GetAudience()
        {
            return "localhost_audience";
        }

        public string GetKey()
        {
            return "my_super_secret_key";
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetKey()));
        }
    }
}
