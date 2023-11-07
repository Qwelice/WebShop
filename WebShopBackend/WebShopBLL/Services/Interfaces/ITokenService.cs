namespace WebShopBLL.Services.Interfaces
{
    using WebShopBLL.DTO;

    public interface ITokenService
    {
        public string GenerateAccessToken(UserDTO userDTO);
        public string GenerateRefreshToken(UserDTO userDTO);
        public bool ValidateToken(string token);
    }
}
