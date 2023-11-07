namespace WebShopBLL.Services.Interfaces
{
    using WebShopBLL.DTO;

    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
        public bool ValidateToken(string token);
    }
}
