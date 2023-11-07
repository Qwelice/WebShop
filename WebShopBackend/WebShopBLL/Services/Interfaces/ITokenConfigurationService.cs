namespace WebShopBLL.Services.Interfaces
{
    using Microsoft.IdentityModel.Tokens;

    public interface ITokenConfigurationService
    {
        public string GetIssuer();

        public string GetAudience();

        public string GetKey();

        public SymmetricSecurityKey GetSymmetricSecurityKey();
    }
}
